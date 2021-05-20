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
    public class HakkımızdaController : Controller
    {
        private IHakkimizdaManager _hakkımızdaManager = new HakkimizdaManager();
        public IActionResult Index()
        {
            var hakkı = _hakkımızdaManager.GetAll();
            return View(hakkı);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Hakkımızda hakkımızda)
        {
            hakkımızda.Id = Guid.NewGuid().ToString();
            bool isSaved = _hakkımızdaManager.Add(hakkımızda);
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

            var hakkımızda = _hakkımızdaManager.GetById(id);
            if (hakkımızda == null)
            {
                return NotFound();
            }
            return View(hakkımızda);

        }


        [HttpPost]
        public ActionResult Edit(Hakkımızda hakkımızda)
        {
            bool isUpdated = _hakkımızdaManager.Update(hakkımızda.Id, hakkımızda);
            if (isUpdated)
            {
                return RedirectToAction("Index");
            }

            return View(hakkımızda);

        }
        public ActionResult Details(string id)
        {

            var hakkımızda = _hakkımızdaManager.GetById(id);
            if (hakkımızda == null)
            {
                return NotFound();

            }
            return View(hakkımızda);

        }
        public ActionResult Delete(string id)
        {
            var hakkımızda = _hakkımızdaManager.GetById(id);
            if (hakkımızda == null)
            {
                return NotFound();

            }
            return View(hakkımızda);
        }
        [HttpPost]
        public ActionResult Delete(Hakkımızda hakkımızda)
        {

            bool isDelete = _hakkımızdaManager.Delete(hakkımızda.Id);
            if (isDelete)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Mgs = "Depo delete failed";
            return View(hakkımızda);
        }
    }
}
