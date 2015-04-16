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
    public class ProjectServiceTest
    {
        private void PrepareTest()
        {
            var model = new Model1();
            //usuwanie bazy

            SqlConnection.ClearAllPools();
            model.Database.Delete();
            Preparator.CreateUserAndProject(model);


        }

        //[Test]
        //public void ProjectList()
        //{
        //    PrepareTest();
        //    IProjectService projectService = new ProjectService();

        //    var model = new ProjectModel();
        //    model.Name = "Project";

           
        //}



    }
}
