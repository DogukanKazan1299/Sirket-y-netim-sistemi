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
    public class DepoController : Controller
    {
        private IDepoManager _depoManager = new DepoManager();
        public IActionResult Index()
        {
            var depos = _depoManager.GetAll();
            return View(depos);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Depo depo)
        {
            depo.Id = Guid.NewGuid().ToString();
            bool isSaved = _depoManager.Add(depo);
            string mgs = "";
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            if (isSaved)
            {
                return RedirectToAction("Index");
            }
            else
            {
                mgs = "Saved failed";
            }
            ViewBag.Mgs = mgs;
            return View();

        }
        public ActionResult Edit(string id)
        {

            var depo = _depoManager.GetById(id);
            if (depo == null)
            {
                return NotFound();
            }
            return View(depo);

        }


        [HttpPost]
        public ActionResult Edit(Depo depo)
        {
            bool isUpdated = _depoManager.Update(depo.Id, depo);
            if (isUpdated)
            {
                return RedirectToAction("Index");
            }

            return View(depo);

        }
        public ActionResult Details(string id)
        {

            var depo = _depoManager.GetById(id);
            if (depo == null)
            {
                return NotFound();

            }
            return View(depo);

         }
        public ActionResult Delete(string id)
        {
            var depo = _depoManager.GetById(id);
            if (depo == null)
            {
                return NotFound();

            }
            return View(depo); 
        }
        [HttpPost]
        public ActionResult Delete(Depo depo)
        {

            bool isDelete = _depoManager.Delete(depo.Id);
            if (isDelete)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Mgs = "Depo delete failed";
            return View(depo);
        }
    }
}
