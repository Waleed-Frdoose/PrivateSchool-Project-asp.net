using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository.CourseR;
using SchoolProject.Repository.RoomR;
using System.Diagnostics;

namespace SchoolProject.Controllers
{
    public class CourseController : Controller
    {

        private readonly ICourseRepository repository;

        public CourseController(ICourseRepository repository)
        {
            this.repository = repository;
        }

        // GET: CourseController
        [HttpGet]
        public ActionResult Index()
        {
            return View(repository.GetCourses());
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            try
            {
                repository.Create(course);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            var course = repository.Find(id);
            if (course != null)
            {
                return View(course);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Course course)
        {
            try
            {
                repository.Edite(course);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: CourseController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Course course)
        {
            try
            {
                repository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
