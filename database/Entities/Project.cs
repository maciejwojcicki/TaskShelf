using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }

        public virtual List<User> Users { get; set; }
        public virtual List<Task> Tasks { get; set; }

        public virtual List<UserPermission> UserPermissions { get; set; }
    }
}
