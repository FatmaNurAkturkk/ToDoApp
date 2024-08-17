using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Common.ResponseObjects;
using ToDoApp.Dtos.Interfaces;
using ToDoApp.Dtos.WorkDtos;

namespace ToDoApp.BussinessLayer.Interfaces
{
    public interface IWorkServices
    {
        Task<IResponse<List<WorkListDtos>>> GetAll();
        Task<IResponse<WorkCreateDto>> Create(WorkCreateDto dto);
        //Task<WorkListDtos> GetById(int id); 
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto);
    }
}
