using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServerSideValidations.CustomAttributes;
using ServerSideValidations.Models.Student;
using System.Collections.Generic;

namespace ServerSideValidations.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            var model = new StudentViewModel
            {
                Courses = GetCourses()
            };
            return View(model);
        }

        private List<SelectListItem> GetCourses()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Text="Physics",Value="1"},
                new SelectListItem{Text="Chemistry",Value="2"},
                new SelectListItem{Text="Mathematics",Value="3"},
                new SelectListItem{Text="Humanities",Value="4"},
                new SelectListItem{Text="Commerce",Value="5"},
            };
        }

        [ValidateAjax]
        public IActionResult Submit(StudentViewModel model)
        {
            if(ModelState.IsValid)
            {
                return Content("Validation checks have passed");
            }
            return View(model);
        }

        
    }
}
