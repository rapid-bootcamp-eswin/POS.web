using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _service;
        public CategoryController(ApplicationContext context)
        {
            _service = new CategoryService(context);
        }

        [HttpGet]
        public IActionResult GetAllCategory()
              {
                    var Data = _service.GetCategory();
                    return View(Data);
              }

        [HttpGet]
        public IActionResult DetailCategory(int? id)
        {
            var DataDetail = _service.GetCategoriesById(id);
            return View(DataDetail);    
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddModal()
        {
            return PartialView("_Add");
        }

        [HttpPost]
        public IActionResult Save([Bind("CategoryName, Description")] CategoryModel request)
        {
            //_service.SaveCategory(request);
            //return Redirect("GetAll");

            if (ModelState.IsValid)
            {
                 _service.SaveCategory(new CategoryEntity(request));
                 return Redirect("GetAllCategory");
              //  _service.Add(new CategoryEntity(request));
               // return Redirect("Index");
            }
            return View("Add", request);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var entity = _service.GetCategoriesById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Update([Bind("Id, CategoryName, Description, ")] CategoryModel request)
        {
            CategoryEntity categoryEntity = new CategoryEntity(request);
            categoryEntity.Id = request.CategoryId;
            _service.UpdateCategories(categoryEntity);
            return Redirect("GetAllCategory");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _service.DeleteById(id);
            return Redirect("GetAllCategory");
        }


    }
}