using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.BussinessLayer.Extensions;
using ToDoApp.BussinessLayer.Interfaces;
using ToDoApp.BussinessLayer.ValidationRules;
using ToDoApp.Common.ResponseObjects;
using ToDoApp.DataAccessLayer.UnitOfWork;
using ToDoApp.Dtos.Interfaces;
using ToDoApp.Dtos.WorkDtos;
using ToDoApp.EntitiesLayer.Domains;

namespace ToDoApp.BussinessLayer.Services
{
    public class WorkService : IWorkServices
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IValidator<WorkCreateDto> _createDtoValidator;
        private readonly IValidator<WorkUpdateDto> _updateDtoValidator;

        public WorkService(IUnitOfWork unitofWork, IMapper mapper, IValidator<WorkCreateDto> createDtoValidator, IValidator<WorkUpdateDto> updateDtoValidator)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<IResponse<WorkCreateDto>> Create(WorkCreateDto dto)
        {
            //var validator = new WorkCreateDtoValidator(); fluentdependencies kütüphaneden önce bu
            var validationResult = _createDtoValidator.Validate(dto);
            
            
            //var validationResult = validator.Validate(dto);
            if (validationResult.IsValid)
            {
                await _unitofWork.GetRepository<Work>().Create(_mapper.Map<Work>(dto));
                await _unitofWork.SaveChanges();
                return new Response<WorkCreateDto>(ResponseType.Success, dto);
            }
            else
            {
                
                return new Response<WorkCreateDto>(ResponseType.ValidationError, dto, validationResult.ConvertToCustomValidationError());
            }
            //await _unitofWork.GetRepository<Work>().Create(new()
            // {
            //     Defination = dto.Defination,
            //     IsCompleted = dto.IsCompleted,
            // });
            
        }

        public async Task<IResponse<List<WorkListDtos>>> GetAll()
        {
            //var list = await _unitofWork.GetRepository<Work>().GetAll();
            //var workList = new List<WorkListDtos>();
            //if (list != null && list.Count > 0)
            //{
            //    foreach (var work in list)
            //    {
            //        workList.Add(new()
            //        {
            //            Defination = work.Defination,
            //            Id = work.Id,
            //            IsCompleted = work.IsCompleted
            //        });
            //    }
            //}
            //return workList;
            //return _mapper.Map<List<WorkListDtos>>(await _unitofWork.GetRepository<Work>().GetAll());
            var data = _mapper.Map<List<WorkListDtos>>(await _unitofWork.GetRepository<Work>().GetAll());
            return new Response<List<WorkListDtos>>(ResponseType.Success, data);
        }

        //public async Task<WorkListDtos> GetById(int id)
        //{
        //    //    var work =await _unitofWork.GetRepository<Work>().GetByFilter(x=>x.Id==id);
        //    //    return new()
        //    //    {
        //    //        Defination = work.Defination,
        //    //        IsCompleted = work.IsCompleted,
        //    //    };
        //    return _mapper.Map<WorkListDtos>(await _unitofWork.GetRepository<Work>().GetByFilter(x => x.Id == id));
        //}
        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            //    var work =await _unitofWork.GetRepository<Work>().GetByFilter(x=>x.Id==id);
            //    return new()
            //    {
            //        Defination = work.Defination,
            //        IsCompleted = work.IsCompleted,
            //    };
            //return _mapper.Map<IDto>(await _unitofWork.GetRepository<Work>().GetByFilter(x => x.Id == id));
            var data = _mapper.Map<IDto>(await _unitofWork.GetRepository<Work>().GetByFilter(x => x.Id == id)); 
            if(data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success,data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntity = await _unitofWork.GetRepository<Work>().GetByFilter(x => x.Id == id);
            if(removedEntity != null)
            {
                _unitofWork.GetRepository<Work>().Remove(removedEntity);
                await _unitofWork.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            
        }

        public async Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto)
        {
            //_unitofWork.GetRepository<Work>().Update(new()
            //{
            //    Defination = dto.Defination,
            //    Id = dto.Id,
            //    IsCompleted = dto.IsCompleted,
            //});
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _unitofWork.GetRepository<Work>().Find(dto.Id);
                if(updatedEntity != null)
                {
                    _unitofWork.GetRepository<Work>().Update(_mapper.Map<Work>(dto),updatedEntity);
                    await _unitofWork.SaveChanges();
                    return new Response<WorkUpdateDto>(ResponseType.Success,dto);
                }
                return new Response<WorkUpdateDto>(ResponseType.NotFound,$"{dto.Id} ye ait data bulunamadı");

            }
            else
            {
                return new Response<WorkUpdateDto>(ResponseType.ValidationError, dto, result.ConvertToCustomValidationError());
            }
            
        }
    }
}
