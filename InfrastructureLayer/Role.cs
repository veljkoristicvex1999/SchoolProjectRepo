﻿using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace InfrastructureLayer
{
    public class Role : RoleProvider
    {
       
        public override string ApplicationName { get; set; }
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
          
            using (TuxContext db = new TuxContext())
            {
                // var user = db.Users.Include("Roles").Where(a => a.Email == username).FirstOrDefault().Roles;
                //int id =  user.First().RoleId;
                // String[] role = { db.Roles.Find(id).RoleName };
                // return role;
                 var user = db.Users.Include("Roles").Where(a => a.Email == username).FirstOrDefault().Roles;
                int id =  user.First().RoleId;
                 String[] role = { db.Roles.Find(id).RoleName };
                 return role;
            }

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