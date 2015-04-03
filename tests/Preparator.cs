using database;
using database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tests
{
    public class Preparator
    {
        public static void CreateUserAndProject (Model1 model)
        {
            var user = new User();
            user.Login = "mkasprzak";
            user.Name = "Mateuszek";
            user.Password = "admin1";
            user.Email = "mkasp@p.pl";
            model.Set<User>().Add(user);
            model.SaveChanges();

            ////To jest dobrze tworzy projekt od striny elementu
            //var label1 = new Label();
            //label1.Name = "Test";
            //label1.Project = new Project
            //{
            //    Name = "taks"
            //};
            //model.Set<Label>().Add(label1);
            //model.SaveChanges();


            ////To jest dobrze tworzy od strony listy
            //var project = new Project();
            //project.Name = "Testowy";
            //project,
            //project.Labels = new List<Label>
            //{
            //    new Label
            //    {
            //        Name="alosza"
            //    }
            //};
            //model.Set<Project>().Add(project);
            //model.SaveChanges();

            var project = new Project();
            project.Name = "test";            
            model.Set<Project>().Add(project);
            model.SaveChanges();

            user.Projects = new List<Project>
            {
                project
            };
            model.SaveChanges();

            var label = new Label();
            label.Name = "test";
            label.Project = project;
            model.Set<Label>().Add(label);
            model.SaveChanges();

            var task = new Task();
            task.Name = "Błąd wyszukiwarki";
            task.Status = Task.TaskStatus.Open;
            task.Type = Task.TaskType.Error;
            task.CreateDate = DateTime.Now;
            task.ExpectedWorkTime = 8;
            task.Project = project;
            model.Set<Task>().Add(task);
            model.SaveChanges();

            
         
            
           
          
        }

      
    }
}
