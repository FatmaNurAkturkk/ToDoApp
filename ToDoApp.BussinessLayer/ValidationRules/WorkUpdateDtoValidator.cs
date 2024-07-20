using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Dtos.WorkDtos;

namespace ToDoApp.BussinessLayer.ValidationRules
{
    public class WorkUpdateDtoValidator:AbstractValidator<WorkUpdateDto>
    {
        public WorkUpdateDtoValidator()
        {
            RuleFor(x => x.Defination).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
