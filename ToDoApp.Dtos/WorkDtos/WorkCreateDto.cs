using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Dtos.Interfaces;

namespace ToDoApp.Dtos.WorkDtos
{
    public class WorkCreateDto:IDto
    {
        //[Required(ErrorMessage ="Definition is required!")] -->DataAnnitions ile yapıldı srp ye aykırı fluentvalidation kullan
        public string? Defination { get; set; }
        public bool IsCompleted { get; set; }
    }
}
