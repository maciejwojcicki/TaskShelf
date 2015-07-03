using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using database.Entities;
using System.ComponentModel.DataAnnotations;
namespace core.Models
{
    public class CreateTaskModel
    {
        [Required]
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int ExpectedWorkTime { get; set; }
        public database.Entities.Task.TaskStatus Status { get; set; }
        public database.Entities.Task.TaskType Type { get; set; }
    }
}
