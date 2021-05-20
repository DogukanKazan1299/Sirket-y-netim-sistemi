using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication39.Interfaces.Manager;
using WebApplication39.Manager;
using WebApplication39.Models;

namespace WebApplication39.Controllers
{
    public class MaasController : Controller
    {
        IMaasManager _maasManager = new MaasManager();
        public IActionResult Index()
        {
            var maasies = _maasManager.GetAll();
            return View(maasies);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Maas maas)
        {
            maas.Id = Guid.NewGuid().ToString();
            bool isSaved = _maasManager.Add(maas);
            string mgs = "";
            if (isSaved)
            {
                mgs = "Maas kaydedildi";
            }
            else
            {
                mgs = "Maas save hatasi";
            }
            ViewBag.Mgs = mgs;
            return View();
        }

    }
}
