using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Dtos.WorkDtos;

namespace ToDoApp.BussinessLayer.ValidationRules
{
    public class WorkCreateDtoValidator:AbstractValidator<WorkCreateDto>
    {
        public WorkCreateDtoValidator()
        {
            //RuleFor(x => x.Defination).NotEmpty().WithMessage("Definition is required!").When(x=>x.IsCompleted).Must(NotBeFatma).WithMessage("Definition fatma olamaz");
            RuleFor(x => x.Defination).NotEmpty();
        }

        //private bool NotBeFatma(string arg)
        //{
        //    return arg != "Fatma" &&  arg != "fatma";
        //}
    }
}
