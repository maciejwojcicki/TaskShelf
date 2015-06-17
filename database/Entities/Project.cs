using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.Entities
{
    public class Project
    {
        public Project()
        {
            Users = new List<User>();
        }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string ImageThumbnail { get; set; }

        public virtual List<User> Users { get; set; }
        public virtual List<Task> Tasks { get; set; }
        public virtual List<UserPermission> UserPermissions { get; set; }
        public virtual List<Label> Labels { get; set; }
        public virtual List<Group> Groups { get; set; }
        public virtual List<Module> Modules { get; set; }
    }
}
