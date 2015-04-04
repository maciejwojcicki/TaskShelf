﻿using core.Models;
using database;
using database.Entities;
using implementations.Interfaces;
using implementations.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using implementations.Exceptions;

namespace implementations.Services
{
    public class UserService : IUserService
    {
        private Model1 context;
        public UserService()
        {

            this.context = new Model1();
            this.context.Configuration.LazyLoadingEnabled = false;
            this.context.Database.Log = (text) =>
            {
                Console.WriteLine(text);
            };
        }
        public int Login(LoginModel model)
        {
            ModelUtils.Validate(model);
           
            var hash = UserUtils.PasswordHash(model.Password);

            var user = context.Set<User>()
                .AsQueryable()       
                .Where(w => w.Login == model.Login && w.Password == hash)
                .Include(i => i.Permissions)               
                .SingleOrDefault();    
                
            if (user == null)
            {
                throw new InvalidLoginPasswordException();
            }

            if (user.ActivationToken != null)
            {
                throw new AccountNotActivatedException();
            }

            if (user.Permissions.Select(p => p.Value)
                .Contains(Permission.PermissionList.CanLogin) == false)
            {
                throw new PermissionException(Permission.PermissionList.CanLogin);
            }

            int userId = user.UserId;

            return userId;
        }
    }
}