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
    public class RaporlarController : Controller
    {
        private IRaporlarManager _raporlarManager = new RaporlarManager();
        public IActionResult Index()
        {
            var raporlars = _raporlarManager.GetAll();
            return View(raporlars);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Raporlar raporlar)
        {
            raporlar.Id = Guid.NewGuid().ToString();
            bool isSaved = _raporlarManager.Add(raporlar);
            string mgs = "";
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

            var raporlar = _raporlarManager.GetById(id);
            if (raporlar == null)
            {
                return NotFound();
            }
            return View(raporlar);

        }


        [HttpPost]
        public ActionResult Edit(Raporlar raporlar)
        {
            bool isUpdated = _raporlarManager.Update(raporlar.Id, raporlar);
            if (isUpdated)
            {
                return RedirectToAction("Index");
            }

            return View(raporlar);

        }
        public ActionResult Details(string id)
        {

            var raporlar = _raporlarManager.GetById(id);
            if (raporlar == null)
            {
                return NotFound();

            }
            return View(raporlar);

        }
        public ActionResult Delete(string id)
        {
            var raporlar = _raporlarManager.GetById(id);
            if (raporlar == null)
            {
                return NotFound();

            }
            return View(raporlar);
        }
        [HttpPost]
        public ActionResult Delete(Raporlar raporlar)
        {

            bool isDelete = _raporlarManager.Delete(raporlar.Id);
            if (isDelete)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Mgs = "Delete failed";
            return View(raporlar);
        }
    }
}
