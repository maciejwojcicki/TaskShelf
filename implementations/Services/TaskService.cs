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


            TaskModel model = new TaskModel();
            model.Tasks.Select(p => p.Project.ProjectId == CurrentProject.ProjectId);
            
            return model.Tasks;
        }
    }
}
