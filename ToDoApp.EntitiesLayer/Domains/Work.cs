﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.EntitiesLayer.Domains
{
    public class Work:BaseEntity
    {        
        public string? Defination { get; set; }
        public bool IsCompleted { get; set; }
    }
}
