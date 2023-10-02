using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository.TeacherR;
using System.Diagnostics;

namespace SchoolProject.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository repository;

        public TeacherController(ITeacherRepository repository)
        {
            this.repository = repository;
        }

        // GET: TeacherController
        [HttpGet]
        public ActionResult Index()
        {
            return View(repository.GetTeachers());
        }

        // GET: TeacherController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher teacher)
        {
            try
            {
                repository.Create(teacher);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Teacher teacher = repository.Find(id);
            if (teacher != null)
            {
                return View(teacher);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: TeacherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Teacher teacher)
        {
            try
            {
                repository.Edite(teacher);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: TeacherController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
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
