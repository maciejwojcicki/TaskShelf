﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.Entities
{
    public class TaskAttachment
    {
        public int TaskAttachmentId { get; set; }
        public string FileName { get; set; }

        public virtual Task Task { get; set; }
    }
}
