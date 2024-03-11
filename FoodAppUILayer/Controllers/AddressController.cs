using FoodAppDALLayer.Interface;
using FoodAppDALLayer.Models;
using FoodAppDALLayer.Repository;
using FoodAppUILayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodAppUILayer.Controllers
{
   
        [Authorize(Roles = "User")]
        public class AddressController : Controller
        {
            private IAddressRepository AddressRepository;

        public AddressController(IAddressRepository addressRepository)
            {
                AddressRepository = addressRepository;
            
            }
            public ActionResult Address()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult SaveAddress(AddressViewModel address)
            {
           
                int customerId = (int)Session["UserId"];
                var UserAddress = AddressRepository.GetAddressesByUserId(customerId);
                foreach (var item in UserAddress)
                {
                    AddressRepository.DeleteAddress(item.Id);

                }

                Address saverAddress = new Address
                {
                    Id = address.Id,
                    State = address.State,
                    Street = address.Street,
                    City = address.City,
                    PostalCode = address.PostalCode,
                    Country = address.Country,
                    UserId = customerId,
                    Latitude = address.Latitude,
                    Longitude = address.Longitude
                };


                AddressRepository.SaveAddress(saverAddress);

                return RedirectToAction("PlaceOrder", "User", new { cartIds = Convert.ToInt32(null), UserId = customerId });
           
            }
        }
    }
