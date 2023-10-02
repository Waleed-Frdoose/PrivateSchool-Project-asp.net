using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository.RoomR;
using SchoolProject.Repository.TeacherR;
using System.Diagnostics;

namespace SchoolProject.Controllers
{
    public class RoomController : Controller
    {

        private readonly IRoomRepository repository;

        public RoomController(IRoomRepository repository)
        {
            this.repository = repository;
        }

        // GET: RoomController
        [HttpGet]
        public ActionResult Index()
        {
            return View(repository.GetRooms());
        }

        // GET: RoomController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Room room)
        {
            try
            {
                repository.Create(room);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoomController/Edit/5
        public ActionResult Edit(int id)
        {
            Room room = repository.Find(id);
            if (room != null)
            {
                return View(room);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: RoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Room room)
        {
            try
            {
                repository.Edite(room);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoomController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: RoomController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Room room)
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
