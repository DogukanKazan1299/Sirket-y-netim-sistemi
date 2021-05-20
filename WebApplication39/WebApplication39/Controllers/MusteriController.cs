using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication39.Interfaces.Manager;
using WebApplication39.Manager;
using WebApplication39.Models;
using X.PagedList;

namespace WebApplication39.Controllers
{
    public class MusteriController : Controller
    {
        private IMusteriManager _musteriManager = new MusteriManager();
        public IActionResult Index(string p)
        {

            var musteris = _musteriManager.GetAll();
            return View(musteris);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Musteri musteri)
        {
            musteri.Id = Guid.NewGuid().ToString();
            bool isSaved = _musteriManager.Add(musteri);
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

            var musteri = _musteriManager.GetById(id);
            if (musteri == null)
            {
                return NotFound();
            }
            return View(musteri);

        }


        [HttpPost]
        public ActionResult Edit(Musteri musteri)
        {
            bool isUpdated = _musteriManager.Update(musteri.Id, musteri);
            if (isUpdated)
            {
                return RedirectToAction("Index");
            }

            return View(musteri);

        }
        public ActionResult Details(string id)
        {

            var musteri = _musteriManager.GetById(id);
            if (musteri == null)
            {
                return NotFound();

            }
            return View(musteri);

        }
        public ActionResult Delete(string id)
        {
            var musteri = _musteriManager.GetById(id);
            if (musteri == null)
            {
                return NotFound();

            }
            return View(musteri);
        }
        [HttpPost]
        public ActionResult Delete(Musteri musteri)
        {

            bool isDelete = _musteriManager.Delete(musteri.Id);
            if (isDelete)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Mgs = "Delete failed";
            return View(musteri);
        }
    }
}
