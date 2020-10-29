﻿using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MoneyBlog.DataLayer.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        readonly DefaultConnection db = new DefaultConnection();
        readonly ApplicationUser applicationUser = new ApplicationUser();
        public List<AspNetUser> AspNetUsers()
        {
            List<AspNetUser> AspNetUsers = db.AspNetUsers.ToList();
            return AspNetUsers;
        }
        public AspNetUser Get(string id)
        {
            var user = db.AspNetUsers.FirstOrDefault(i => i.Id == id);
            return user;
        }
        public void Update(AspNetUser aspNetUser)
        {
           db.AspNetUsers.AddOrUpdate(aspNetUser);
           db.SaveChanges();
        }
        public void Delete(string id)
        {
            db.AspNetUsers.Remove(db.AspNetUsers.Find(id));
            db.SaveChanges();
        }
        public AspNetRole GetUserRole(string id)
        {
            var role = db.AspNetRoles.FirstOrDefault(i => i.Id == id);
            return role;
        }

    }
}
