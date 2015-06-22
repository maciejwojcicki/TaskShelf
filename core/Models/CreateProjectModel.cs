using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Models
{
    public class CreateProjectModel
    {
        [Required]
        public string Name { get; set; }
        public string Imagethumbnail { get; set; }
    }
}
