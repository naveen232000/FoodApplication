﻿using FoodAppDALLayer.ApplicationDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace FoodAppUILayer.Provider
{
    public class WebRoleProvider : RoleProvider
    {
        private readonly FoodAppDbContext context;
        public WebRoleProvider()
        {
            context = new FoodAppDbContext();
        }
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            var result = from user in context.Users

                         join role in context.Roles on user.RoleId equals role.RoleId
                         where user.UserName == username
                         select role.Name;
            if (!result.Any())
            {
                result = from rest in context.Restaurants
                         join role in context.Roles on rest.RoleId equals role.RoleId
                         where rest.Email == username
                         select role.Name;
            }
            // Check if the user, then check in the Admins table
            if (!result.Any())
            {
                result = from admin in context.Admins
                         join role in context.Roles on admin.RoleId equals role.RoleId
                         where admin.UserName == username
                         select role.Name;
            }

            return result.ToArray();
            //throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}