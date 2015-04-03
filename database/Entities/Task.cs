using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.Entities
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int ExpectedWorkTime { get; set; }
        public DateTime CompletedDate { get; set; }
        public TaskStatus Status { get; set; }
        public TaskType Type { get; set; }

        public virtual Project Project { get; set; }
        public virtual List<TaskAttachment> TaskAttachments { get; set; }
        public virtual CheckList CheckList { get; set; }
        public virtual List<TaskComment> TaskComments { get; set; }
        

        public enum TaskStatus
        {
            Open,
            InProgress,
            Completed
        }

        public enum TaskType
        {
            Error,
            Test,
            Refactor,
            Story
        }
    }
}
