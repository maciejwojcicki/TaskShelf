﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Models
{
    public class ProjectModel
    {
       public List<database.Entities.Project> Projects { get; set; }
    }
}
