using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Context;
using SchoolProject.Models;
using SchoolProject.Repository.StudentR;
using System.Diagnostics;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace SchoolProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository repository;
        private readonly IHostingEnvironment environment; //wwwroot يجيبلي الباث يلي رح حط فيهم الصور يلي هو جوا ال 

        public StudentController(IStudentRepository repository, IHostingEnvironment environment)
        {
            this.repository = repository;
            this.environment = environment;
        }
        //var dataBase = new AppDbContext();
        // GET: StudentController
        // list of student
        [HttpGet]
        public ActionResult Index()
        {
            return View(repository.GetStudents());
        }

        // GET: StudentController/Create
        // creat student view
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        // create view proccess
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student,IFormFile studentPhoto)
        {
            try
            {
                repository.Uplodephoto(student,studentPhoto, environment);

                repository.Create(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            Student student = repository.Find(id);
            if (student != null)
            {
                return View(student);
            }
            return RedirectToAction(nameof(Index));
            
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student, IFormFile studentPhoto)
        {
            try
            {
                repository.Uplodephoto(student, studentPhoto, environment);

                repository.Edit(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: StudentController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            
                repository.Delete(id);
                return RedirectToAction(nameof(Index));
            
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(int studentId, int courseId)
        {
            try
            {
                repository.Register(studentId, courseId);
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
