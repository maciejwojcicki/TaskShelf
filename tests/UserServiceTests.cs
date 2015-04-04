using core.Models;
using database;
using implementations.Interfaces;
using implementations.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    public class UserServiceTests
    {
        private void PrepareTest()
        {
            var model = new Model1();
            //usuwanie bazy

            SqlConnection.ClearAllPools();
            model.Database.Delete();
            Preparator.CreateUserAndProject(model);


        }

        [Test]
        public void AdminLogin()
        {
            PrepareTest();
            IUserService userService = new UserService();

            var model = new LoginModel();
            model.Login = "mkasprzak";
            model.Password = "123456";
            int userId = userService.Login(model);
            Assert.Greater(userId, 0);
        }
    }
}
