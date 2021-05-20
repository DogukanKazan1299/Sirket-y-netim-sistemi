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
    public class LoginController : Controller
    {
        private ILoginManager _loginManager = new LoginManager();
        public IActionResult Index()
        {
            var logins = _loginManager.GetAll();
            return View(logins);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Login login)
        {
            login.Id = Guid.NewGuid().ToString();
            bool isSaved = _loginManager.Add(login);
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

            var login = _loginManager.GetById(id);
            if (login == null)
            {
                return NotFound();
            }
            return View(login);

        }


        [HttpPost]
        public ActionResult Edit(Login login)
        {
            bool isUpdated = _loginManager.Update(login.Id, login);
            if (isUpdated)
            {
                return RedirectToAction("Index");
            }

            return View(login);

        }
        public ActionResult Details(string id)
        {

            var login = _loginManager.GetById(id);
            if (login == null)
            {
                return NotFound();

            }
            return View(login);

        }
        public ActionResult Delete(string id)
        {
            var login = _loginManager.GetById(id);
            if (login == null)
            {
                return NotFound();

            }
            return View(login);
        }
        [HttpPost]
        public ActionResult Delete(Login login)
        {

            bool isDelete = _loginManager.Delete(login.Id);
            if (isDelete)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Mgs = "Delete failed";
            return View(login);
        }
    }
}
