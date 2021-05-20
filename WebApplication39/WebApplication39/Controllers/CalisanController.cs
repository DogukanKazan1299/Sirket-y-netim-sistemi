using Microsoft.AspNetCore.Authorization;
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
    public class CalisanController : Controller
    {
        private ICalisanManager _calisanManager = new CalisanManager();
        IMaasManager _maasManager = new MaasManager();
        [AllowAnonymous]
        public IActionResult Index()
        {
            var calisanlar = _calisanManager.GetAll();
            return View(calisanlar);
        }
        public ActionResult Create()
        {
            ViewBag.Maasies = _maasManager.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Calisan calisan, Microsoft.AspNetCore.Http.IFormFile Image)
        {
            calisan.Id = Guid.NewGuid().ToString();
            var maas = _maasManager.GetById(calisan.MaasId);
            ViewBag.Maasies = _maasManager.GetAll();
            calisan.Maas = maas;
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            if (Image != null)
            {
                MemoryStream memoryStream = new MemoryStream();
                Image.OpenReadStream().CopyTo(memoryStream);
                calisan.Image = Convert.ToBase64String(memoryStream.ToArray());
            }
            else
            {
                calisan.Image = "";
            }
            bool isSaved = _calisanManager.Add(calisan);
            string mgs = "";
            if (isSaved)
            {
                return RedirectToAction("Index");
            }
            else
            {
                mgs = "Save hatasi";
            }
            ViewBag.Mgs = mgs;
            return View();
        }

        public ActionResult Edit(string id)
        {
            var calisan = _calisanManager.GetById(id);
            ViewBag.Maasies = _maasManager.GetAll();
            if (calisan == null)
            {
                return NotFound();
            }
            return View(calisan);
        }

        [HttpPost]
        public ActionResult Edit(Calisan calisan)
        {
            ViewBag.Maasies = _maasManager.GetAll();
            var maas = _maasManager.GetById(calisan.MaasId);
            calisan.Maas = maas;
            bool isUpdated = _calisanManager.Update(calisan.Id,calisan);
            if (isUpdated)
            {
                return RedirectToAction("Index");
            }
            return View(calisan);
        }

        public ActionResult Details(string id)
        {
            var calisan = _calisanManager.GetById(id);
            if (calisan == null)
            {
                return NotFound();
            }
            return View(calisan);
        }

        public ActionResult Delete(string id)
        {
            var calisan = _calisanManager.GetById(id);
            if (calisan == null)
            {
                return NotFound();
            }
            return View(calisan);
        }

        [HttpPost]
        public ActionResult Delete(Calisan calisan)
        {
            bool isDelete = _calisanManager.Delete(calisan.Id);
            if (isDelete)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Mgs = "Calisan silme islemi hatasi";
            return View(calisan);
        }
    }
}
