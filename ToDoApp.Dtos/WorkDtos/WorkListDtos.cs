using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Dtos.Interfaces;

namespace ToDoApp.Dtos.WorkDtos
{
    public class WorkListDtos:IDto
    {
        public int Id { get; set; }
        public string? Defination { get; set; }
        public bool IsCompleted { get; set; }
    }
}
