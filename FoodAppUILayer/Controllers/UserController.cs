using FoodAppDALLayer.Interface;
using FoodAppDALLayer.Models;
using FoodAppDALLayer.Repository;
using FoodAppUILayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using FoodAppDALLayer.ApplicationDbContext;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Net;
using System.Reflection;
using FoodAppDALLayer.Migrations;

namespace FoodAppUILayer.Controllers
{
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        public UserController()
        {

        }
  
        private readonly IFoodItemRepository foodItemRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IRestaurantRepository restaurantRepository;
        private readonly ICartRepository cartRepository;
        private readonly IUserRepository userRepository;
        private readonly IAddressRepository addressRepository;
        private readonly IOrderItemRepository orderItemRepository;

        private readonly IOrderRepository orderRepository;

        public UserController(IRestaurantRepository restaurantRepository, ICategoryRepository categoryRepository, IFoodItemRepository foodItemRepository, ICartRepository cartRepository, IUserRepository userRepository, IAddressRepository addressRepository, IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
        {
            this.foodItemRepository = foodItemRepository ?? throw new ArgumentNullException(nameof(foodItemRepository));
            this.categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            this.restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
            this.cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.addressRepository = addressRepository ?? throw new ArgumentNullException(nameof(addressRepository));
            this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.orderItemRepository = orderItemRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public ActionResult AllRestaurant()
        {

            var rest = restaurantRepository.GetAllRestaurants();
            var top5orders = orderRepository.GetTop5OrdersByFoodId();
            ViewBag.Top5Orders = top5orders;

            var restaurantModel = rest.Select(MapToViewModel).ToList();

            return View(restaurantModel);
        }
        //MapToViewModel for Restaurant
        private Restaurant MapToViewModel(Restaurant rest)
        {
            return new Restaurant
            {
            RestId = rest.RestId,
            Name = rest.Name,
            Address = rest.Address,
            City = rest.City,
            Email = rest.Email,
            Mobile = rest.Mobile,
            Latitude = rest.Latitude,
            Longitude = rest.Longitude, 
            Image = rest.Image,

            };
        }

        public ActionResult AllFoodItems(int id)
        {
            var foodItem = foodItemRepository.GetFoodItemByRestId(id);
          
            var foodItemModel = foodItem.Select(MapToViewModel).ToList();

            return View(foodItemModel);

        }
       


        private FoodItem MapToViewModel(FoodItem foodItem)
        {
            return new FoodItem
            {
                FoodId = foodItem.FoodId,
                Availability = foodItem.Availability,
                Name = foodItem.Name,
                Image = foodItem.Image,
                Category = foodItem.Category,
                Description = foodItem.Description,
                Restaurant = foodItem.Restaurant,
                RestId = foodItem.RestId,
                Price = foodItem.Price,
            };
        }

        //cart
        [HttpPost]
        public ActionResult AddToCart(int foodItemId)
        {
            var userId = Session["UserId"] as int?;
            if (userId == null)
            {
                ModelState.AddModelError("errorMessage", "User session not found. Please log in.");
                return RedirectToAction("UserLogin", "Account");
            }
            int temp = Convert.ToInt32(userId);
            var existingCartItems = cartRepository.GetCartItemsByUserId(temp);
            var foodItems = foodItemRepository.GetFoodItemById(foodItemId);
            if (existingCartItems.Any())
            {
                bool sameRestaurant = existingCartItems.All(item => item.RestId ==foodItems.RestId);

                if (!sameRestaurant)
                {
                    TempData["Error"] = "You can only add items from the same restaurant to your cart. Please remove your current cart items before adding items from a new restaurant.";
                    return RedirectToAction("ViewCart", new { userId = temp }); 
                }
            }
            var existingCartItem = cartRepository.GetCartItemByfIdUid(foodItemId, temp);
          
          
            if (existingCartItem != null)
            {
               
                existingCartItem.Quantity++;
                cartRepository.Save();
            }
            else
            {
                var foodItem = foodItemRepository.GetFoodItemById(foodItemId);

                if (foodItem == null)
                {
                    ModelState.AddModelError("errorMessage", "Product not found.");
                    return RedirectToAction("AllRestaurant");
                }


                var addTocart = new Cart
                {
                    FoodId = foodItemId,
                    UserId = temp,
                    Quantity = 1,
                    Price = foodItem.Price,
                    RestId = foodItem.RestId,
                    destinationLatitude= restaurantRepository.GetRestaurantById(foodItem.RestId).Latitude,
                    destinationLongitude= restaurantRepository.GetRestaurantById(foodItem.RestId).Longitude

                };

                cartRepository.InsertCart(addTocart);
                cartRepository.Save();

            }
            TempData["Success"] = "Item Added to Cart successfully";

            return RedirectToAction("AllRestaurant");
        }
        public ActionResult ViewCart(int? userId)
        {
           
            if (userId == null)
            {
               
                return RedirectToAction("UserLogin", "Account");
            }
            
            var cartItems = cartRepository.GetCartItemsByUserId(userId);
      
            var carViewList = cartItems.Select(item => new Cart
            {
                CartId = item.CartId,
                UserId = item.UserId,
                Quantity = item.Quantity,
                Price = item.Price,
                FoodItem = foodItemRepository.GetFoodItemById(item.FoodId),
                FoodId=item.FoodId,
                RestId = item.RestId,
                Restaurant= restaurantRepository.GetRestaurantById(item.RestId),
                destinationLatitude = restaurantRepository.GetRestaurantById(item.RestId).Latitude,
                destinationLongitude = restaurantRepository.GetRestaurantById(item.RestId).Longitude

            });
           
            return View(carViewList);
        }

        [HttpPost]
        public ActionResult UpdateCartQuantity(int cartId, int newQuantity)
        {

            var cartItem = cartRepository.GetCartById(cartId);
            var foodItem = foodItemRepository.GetFoodItemById(cartItem.FoodId);
            if (!foodItem.Availability)
            {
                return Json(new { success = false, errorMessage = $" Item Not Available ." });
            }

            if (cartItem != null)
            {
                cartItem.Quantity = newQuantity;

                cartRepository.Save();
                var subtotal = cartItem.Quantity * cartItem.Price;
                return Json(new { success = true, subtotal });
            }
            return Json(new { success = true });
        }

        //RemoveCartItem
        [HttpPost]
        public ActionResult RemoveCartItem(int cartId)
        {
            int userid = Convert.ToInt32(Session["UserId"]);
           
            if (userid == 0)
            {
                TempData["ErrorMessage"] = "User not logged in.";
                return RedirectToAction("ViewCart", new { userId = userid });
            }

            var cartItem = cartRepository.GetCartItemByCartIdUid(cartId, userid);

            if (cartItem == null)
            {
                TempData["ErrorMessage"] = "Cart item not found.";
                return RedirectToAction("ViewCart", "User", new { userId = userid });
            }

            cartRepository.DeleteCart(cartItem.CartId);
            cartRepository.Save();
            return RedirectToAction("ViewCart", "User", new { userId = userid });
        }

        //orders
    
        public ActionResult PlaceOrder(int? userId)
        {

            if (userId == null)
            {
                var existingOrder = Session["OrderViewModel"] as OrderViewModel;
                return View(existingOrder);
            }
            else
            {
                var cartItems2 = cartRepository.GetCartItemsByUserId(userId);
                int[] cartIds1 = cartItems2.Select(item => item.CartId).ToArray();
                int custId = Convert.ToInt32(userId);
                var cartItems = cartRepository.GetCartItemById(cartIds1);
                var customer = userRepository.GetUserById(custId);
                var UserAddress = addressRepository.GetAddressesByUserId(custId);
                List<AddressViewModel> addressModel = null;

                if (UserAddress != null && UserAddress.Any())
                {
                    addressModel = UserAddress.Select(address => new AddressViewModel
                    {
                        Id = address.Id,
                        Street = address.Street,
                        City = address.City,
                        PostalCode = address.PostalCode,
                        State = address.State,
                        Country = address.Country,
                        Longitude = address.Longitude,
                        Latitude = address.Latitude,
                    }).ToList();
                }
                var order = new OrderViewModel
                {

                    UserId = customer.UserId,
                    User = userRepository.GetUserById(custId),
                    FoodId= cartItems.FirstOrDefault().FoodId,
                    FoodItem= cartItems.FirstOrDefault().FoodItem,
                    DateOfOrder = DateTime.Now,
                    Addresses=addressModel,
                    destinationLatitude= cartItems.FirstOrDefault().destinationLatitude,
                    destinationLongitude= cartItems.FirstOrDefault().destinationLongitude,

                    OrderDetails = cartItems.Select(item => new OrderDetailsViewModel
                    {

                        FoodItemName = item.FoodItem.Name,
                        Quantity = item.Quantity,
                        Price = item.Price,
                        Subtotal = item.Quantity * item.Price,
                        FoodItemId = item.FoodId,

                    }).ToList()
                };
                decimal total = cartItems.Sum(item => item.Quantity * item.Price);
                order.TotalAmount = total;
                Session["OrderViewModel"] = order;

                return View(order);
            }
        }

        [HttpPost]
        public ActionResult OrderConfirm(int userId, decimal subtotal, string paymentType)
        {
            var sectionaddrs = Session["OrderViewModel"] as OrderViewModel;
            var addresses = sectionaddrs.Addresses;
            var cartItems = cartRepository.GetCartItemsByUserId(userId);
            var user = userRepository.GetUserById(userId);
            var address = addressRepository.GetAddressesById(addresses.First().Id);
            int rid = cartItems.FirstOrDefault().RestId;
            var rest = restaurantRepository.GetRestaurantById(rid);
            restaurantRepository.Detach(rest);
            var order=orderRepository.GetOrderCountByUserId(userId);
            var foodItemIds = cartItems.Select(item => item.FoodId).ToList();
            decimal deliveryCh = subtotal - cartItems.Sum(item => item.Quantity * item.Price);
            decimal discount = 0;
            if (order == 0)
            {
                discount = 10;
                subtotal = subtotal - (subtotal * (discount / 100));

            }
            else if(order >3)
            {
                discount = 30;
                subtotal = subtotal - (subtotal * (discount / 100));
            }
           
            DateTime now = DateTime.Now;
            
         
            DateTime estimatedDeliveryTime = now.AddHours(2);
          
            
            var newOrder = new Order
            {
                DateOfOrder = now,
                UserId = user.UserId,
                TotalAmount = subtotal,
                DeliveryAddress = $"{address.FirstOrDefault().Street} {address.FirstOrDefault().City} {address.FirstOrDefault().PostalCode} {address.FirstOrDefault().Country}",
                DeliveryCharge = deliveryCh,
                Qty = cartItems.Sum(item => item.Quantity),
                OrderStatus = "Preparing Order",
                PaymentType = paymentType,
                PaymentStatus = "Pending",
                Discount = discount,
                EstimatedDeliveryTime = estimatedDeliveryTime,
                FoodId= foodItemIds.FirstOrDefault(),
                

            };
            userRepository.Detach(user);
            addressRepository.Detach(address.FirstOrDefault());
       
            int orderId = orderRepository.InsertOrder(newOrder);
            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (var cartItem in cartItems)
            {
                orderItems.Add(new OrderItem
                {
                    OrderId= orderId,
                    FoodId = cartItem.FoodId,
                    Quantity = cartItem.Quantity,
                    Price = cartItem.Price
                });
            }

            var orders1 = orderRepository.GetOrderById(orderId);
            orders1.OrderItems = orderItems;
            orderRepository.UpdateOrder(orders1);
            orderRepository.Save();

            // Remove cart items
            foreach (var cartItem in cartItems)
            {
                cartRepository.DeleteCart(cartItem.CartId);
            }
            cartRepository.Save();

            return RedirectToAction("OrderConfirmation", new { orderId = orderId });
        }

        public ActionResult OrderConfirmation(int orderId)
        {
            var order = orderRepository.GetOrderByodId(orderId);

            return View(order);
        }

        //edit user
        public ActionResult EditUser(int id)
        {
            var user = userRepository.GetUserById(id);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found.");
                return View();
            }

            var viewModel = new User
            {
                UserId = id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Mobile = user.Mobile,
                Password = user.Password,
                RoleId = user.RoleId
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(User model)
        {
            if (ModelState.IsValid)
            {
               
                var user = userRepository.GetUserById(model.UserId);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "user not found.");
                    return View(model);
                }
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.UserName;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.Mobile = model.Mobile;
                user.Password=user.Password;
                user.RoleId = user.RoleId;

                
                try
                {
                    userRepository.Save();
                    TempData["Success"] = "Profile Edited Successfully";
                    return RedirectToAction("AllRestaurant");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while processing your request. Please try again later.");
                }
            }

            return View(model);
        }

        public ActionResult OrderByUser()
        {
            int userid = Convert.ToInt32(Session["UserId"]);
            var orders = orderRepository.GetOrderByUserId(userid);
            var orderModel = orders.Select(MapToViewModel).ToList();
            return View(orderModel);
        }
       
        private Order MapToViewModel(Order ord)
        {
            return new Order
            {
             OrderId = ord.OrderId,
             FoodId = ord.FoodId,
             FoodItem = ord.FoodItem,
             OrderItems = ord.OrderItems,
             OrderStatus = ord.OrderStatus,
             DateOfOrder = ord.DateOfOrder,
             DeliveryAddress = ord.DeliveryAddress,
             TotalAmount = ord.TotalAmount,
            };
        }


        public ActionResult DeleteOrder(int id)
        {

            Order orderToDelete = orderRepository.GetOrderById(id);
            if (orderToDelete != null)
            {
              
                orderRepository.DeleteOrder(id);
                orderRepository.Save();
                TempData["DeleteMsg"] = "Order Canceled";
            }

            return RedirectToAction("OrderByUser");
        }
    }
}