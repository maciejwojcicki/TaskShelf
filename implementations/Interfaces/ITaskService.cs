using core.Models;
using database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace implementations.Interfaces
{
    public interface ITaskService
    {
        List<Task> GetTasks(IPrincipal CurrentPrincipal, int projectId);
        void CreateTask(CreateTaskModel model,int projectId);
    }
}
