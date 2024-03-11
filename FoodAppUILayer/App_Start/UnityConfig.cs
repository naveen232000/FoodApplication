using FoodAppDALLayer.Interface;
using FoodAppDALLayer.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace FoodAppUILayer.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IAdminRepository, AdminRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IRestaurantRepository, RestaurantRepository>();
            container.RegisterType<IRatingRepository, RatingRepository>();
            container.RegisterType<IOrderRepository, OrderRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IFoodItemRepository, FoodItemRepository>();
            container.RegisterType<ICartRepository, CartRepository>();
            container.RegisterType<IAddressRepository, AddressRepository>();
            container.RegisterType<IOrderItemRepository, OrderItemRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}