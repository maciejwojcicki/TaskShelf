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
        public List<Project> GetProjects(IPrincipal currentPrincipal)
        {
            User user = userService.GetCurrentUser(currentPrincipal);
            if (user == null)
            {
                throw new NotLoggedInException();
            }

            ProjectModel model = new ProjectModel();
            model.Projects = context.Set<Project>()
                .Where(w => w.Users.Select(s=>s.UserId).Contains(user.UserId)).ToList();

            return model.Projects;
        }
        public void CreateProject(CreateProjectModel model, IPrincipal currentPrincipal)
        {
            ModelUtils.Validate(model);

            var project = new Project();
            project.Name = model.Name;
            project.ImageThumbnail = model.ImageThumbnail;
            
            context.Set<Project>().Add(project);
            context.SaveChanges();

            User user = userService.GetCurrentUser(currentPrincipal);
            user.Projects = new List<Project>
            { 
                
                
            };
            context.Set<User>().(user);
            context.SaveChanges();

        }
    }
}
