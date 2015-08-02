using core.Models;
using database;
using database.Entities;
using implementations.Interfaces;
using implementations.Utils;
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

        public void CreateTask(CreateTaskModel model,int projectId)
        {
            ModelUtils.Validate(model);

            var project = context.Set<Project>().Single(p => p.ProjectId == projectId);

            var task = new Task();
            task.Name = model.Name;
            task.Description = model.Description;
            task.CreateDate = DateTime.Now;
            task.ExpectedWorkTime = model.ExpectedWorkTime;
            task.Status = Task.TaskStatus.Open;
            task.Type = model.Type;
            task.Project = project;
            
            context.Set<Task>().Add(task);
            context.SaveChanges();
            var test = task.TaskId;
            var select = context.Set<Task>().Find(task.TaskId);
            var attachment = new TaskAttachment();
            foreach (var item in model.Attachments)
            {
                attachment.Task = select;
                attachment.FileName = item.FileName;
                context.Set<TaskAttachment>().Add(attachment);
                context.SaveChanges();

            }
            
            
        }
    }
}
