using core.Models;
using database;
using database.Entities;
using implementations.Exceptions;
using implementations.Interfaces;
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
        public ProjectService()
        {

            this.context = new Model1();
            this.context.Configuration.LazyLoadingEnabled = false;
            this.context.Database.Log = (text) =>
            {
                Console.WriteLine(text);
            };
        }
        public List<Project> GetProjects(IPrincipal currentPrincipal)
        {
            UserService userService = new UserService();
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
    }
}
