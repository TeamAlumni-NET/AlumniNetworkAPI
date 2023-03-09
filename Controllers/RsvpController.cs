using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlumniNetworkAPI.Controllers
{
    public class RsvpController : Controller
    {
        // GET: RsvpController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RsvpController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RsvpController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RsvpController/Create
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

        // GET: RsvpController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RsvpController/Edit/5
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

        // GET: RsvpController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RsvpController/Delete/5
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
