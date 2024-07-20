using Microsoft.AspNetCore.Mvc;
using ToDoApp.BussinessLayer.Interfaces;
using ToDoApp.Common.ResponseObjects;
using ToDoApp.Dtos.Interfaces;
using ToDoApp.Dtos.WorkDtos;
using ToDoApp.UI.Extensions;

namespace ToDoApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkServices _workService;

        public HomeController(IWorkServices workService)
        {
            _workService = workService;

        }

        public async Task<IActionResult> Index()
        {
            //var workList = await _workService.GetAll();
            //return View(workList);
            var response = await _workService.GetAll();
            return View(response.Data);
            
        }
        public IActionResult Create()
        {
            return View(new WorkCreateDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto dto)
        {
            var response = await _workService.Create(dto);
            return this.ResponseRedirectoAction(response, "Index");
            //if(response.ResponseType == ResponseType.ValidationError)
            //{
            //    foreach (var error in response.ValidationErrors)
            //    {
            //        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            //    }
            //    return View(dto);
                
            //}
            //else
            //{
            //    return RedirectToAction("Index");
            //}           
            

        }
        public async Task<IActionResult> Update(int id)
        {
            /*var dto = await _workService.GetById(id);
            //return View(new WorkUpdateDto
            //{
            //    Id=dto.Id,
            //    Defination=dto.Defination,
            //    IsCompleted=dto.IsCompleted
            //});
            return View(_mapper.Map<WorkUpdateDto>(dto));*/
            //return View(await _workService.GetById<WorkUpdateDto>(id));
            var response= (await _workService.GetById<WorkUpdateDto>(id));
            return this.ResponseView(response);
            //if (response.ResponseType == ResponseType.NotFound)
            //    return NotFound();
            //return View(response.Data);

        }
        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto dto)
        {
            var response = await _workService.Update(dto);
            return this.ResponseRedirectoAction(response,"Index");
            //if(response.ResponseType == ResponseType.Success)
            //{
            //    foreach (var error in response.ValidationErrors)
            //    {
            //        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            //    }
            //    return View(dto);
            //}
            //return RedirectToAction("Index");
        }
        public async Task<IActionResult> Remove(int id)
        {
            var response = await _workService.Remove(id);
            return this.ResponseRedirectoAction(response, "Index");
            //if (response.ResponseType == ResponseType.NotFound)
            //    return NotFound();           
            //return RedirectToAction("Index");
        }
        public IActionResult NotFound(int code)
        {
            return View();
        }
    }
}
