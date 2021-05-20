using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication39.Interfaces.Manager;
using WebApplication39.Manager;
using WebApplication39.Models;

namespace WebApplication39.Controllers
{
    public class IsController : Controller
    {
        private IIsManager _isManager = new IsManager();
        public IActionResult Index()
        {
            var iss = _isManager.GetAll();
            return View(iss);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Is iss)
        {
            iss.Id = Guid.NewGuid().ToString();
            bool isSaved = _isManager.Add(iss);
            string mgs = "";
            if (isSaved)
            {
                return RedirectToAction("Index");
            }
            else
            {
                mgs = "Saved failed";
            }
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            ViewBag.Mgs = mgs;
            return View();

        }
        public ActionResult Edit(string id)
        {

            var iss = _isManager.GetById(id);
            if (iss == null)
            {
                return NotFound();
            }
            return View(iss);

        }


        [HttpPost]
        public ActionResult Edit(Is iss)
        {
            bool isUpdated = _isManager.Update(iss.Id, iss);
            if (isUpdated)
            {
                return RedirectToAction("Index");
            }

            return View(iss);

        }
        public ActionResult Details(string id)
        {

            var iss = _isManager.GetById(id);
            if (iss == null)
            {
                return NotFound();

            }
            return View(iss);

        }
        public ActionResult Delete(string id)
        {
            var iss = _isManager.GetById(id);
            if (iss == null)
            {
                return NotFound();

            }
            return View(iss);
        }
        [HttpPost]
        public ActionResult Delete(Is iss)
        {

            bool isDelete = _isManager.Delete(iss.Id);
            if (isDelete)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Mgs = "Depo delete failed";
            return View(iss);
        }
    }
}
