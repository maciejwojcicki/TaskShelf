using database;
using database.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    public class DbTest
    {
        [Test]
        public void DatabaseTest()
        {

            var model = new Model1();
            
            model.Set<User>().Add(new User()
            {
                Login = "uzytkownik"
            });
            model.SaveChanges();


        }
    }
}
