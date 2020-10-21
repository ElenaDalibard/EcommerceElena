using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceElena.DataAccess;
using EcommerceElena.Models;

namespace EcommerceElena.Controllers
{
    public class DetailCommandeController : Controller
    {
        Repository<DetailCommande> repDetailCommande = new EFRepository<DetailCommande>();

        // GET: DetailCommande
        public ActionResult Index()
        {
            return View(repDetailCommande.Lister());
        }

        // GET: DetailCommande/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DetailCommande/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetailCommande/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DetailCommande/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DetailCommande/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DetailCommande/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DetailCommande/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
