using core.Models;
using database;
using database.Entities;
using implementations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;


namespace implementations.Services
{
    public class TaskService : ITaskService
    {
        private Model1 context;
        ITaskService taskService = null;
        public TaskService()
        {
            this.context = new Model1();
            this.context.Configuration.LazyLoadingEnabled = false;
            this.context.Database.Log = (text) =>
            {
                Console.WriteLine(text);
            };
        }
        public List<Task> GetTasks(IPrincipal CurrentPrincipal, int projectId)
        {
            var CurrentProject = context.Set<Project>().Single(p => p.ProjectId == projectId);

            
      
            var model = context.Set<Task>().Where(p=>p.Project.ProjectId.Equals(CurrentProject.ProjectId)).ToList();
            
            return model;
        }
    }
}
