using core.Models;
using database;
using database.Entities;
using implementations.Exceptions;
using implementations.Interfaces;
using implementations.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace implementations.Services
{
    public class ProjectService : IProjectService
    {
        private Model1 context;
        IUserService userService = null;
        public ProjectService()
        {

            this.context = new Model1();
            this.context.Configuration.LazyLoadingEnabled = false;
            this.context.Database.Log = (text) =>
            {
                Console.WriteLine(text);
            };
            userService = new UserService();
        }
        public List<ProjectModel> GetProjects(IPrincipal currentPrincipal)
        {

            User user = userService.GetCurrentUser(currentPrincipal);
            if (user == null)
            {
                throw new NotLoggedInException();
            }
            //z dupy zapytanie do przerobienia!

            //var test =  context.Set<Project>()
            //    .Where(w => w.Users.Select(s=>s.UserId).Equals(user.UserId));

            var zzz = from o in context.Set<Project>()
                      from k in o.Users
                      where k.UserId.Equals(user.UserId)
                      select new ProjectModel { Project = o };

            return zzz.ToList() ;
        }
        public void CreateProject(CreateProjectModel model, IPrincipal currentPrincipal)
        {
            var ProjectExist = context.Set<Project>().Where(p => p.Name.Equals(model.Name)).Count();
            if(ProjectExist !=0)
            {
                throw new ProjectExist();
            }

            var project = new Project();
            project.Name = model.Name;
            project.ImageThumbnail = model.Imagethumbnail;
            context.Set<Project>().Add(project);
            context.SaveChanges();

            User CurrentUser = userService.GetCurrentUser(currentPrincipal);
            var user = context.Set<User>().Single(p => p.UserId == CurrentUser.UserId);

            user.Projects = new List<Project>
            {
                project
            };
            context.SaveChanges();
        }
    }
}
