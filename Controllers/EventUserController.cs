using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlumniNetworkAPI.Controllers
{
    public class EventUserController : Controller
    {
        // GET: EventUserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EventUserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EventUserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventUserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventUserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EventUserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventUserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EventUserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
