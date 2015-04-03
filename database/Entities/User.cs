using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public virtual List<Project> Projects { get; set; }
        public virtual List<Permission> Permissions { get; set; }
        public virtual List<UserPermission> UserPermissions { get; set; }
        public virtual List<Group> Groups { get; set; }
        public virtual List<TaskComment> TaskComments { get; set; }
    }
}
