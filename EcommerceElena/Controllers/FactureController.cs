using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceElena.DataAccess;
using EcommerceElena.Models;

namespace EcommerceElena.Controllers
{
    public class FactureController : Controller
    {
        Repository<Facture> repFacture = new EFRepository<Facture>();

        // GET: Facture
        public ActionResult Index()
        {
            return View(repFacture.Lister());
        }

        // GET: Facture/Details/5
        public ActionResult Details(int id)
        {
            return View(repFacture.Trouver(id));
        }

        // GET: Facture/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Facture/Create
        [HttpPost]
        public ActionResult Create(Facture facture)
        {
            try
            {
                repFacture.Ajouter(facture);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Facture/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repFacture.Trouver(id));
        }

        // POST: Facture/Edit/5
        [HttpPost]
        public ActionResult Edit(Facture facture)
        {
            try
            {
                repFacture.Modifier(facture);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Facture/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repFacture.Trouver(id));
        }

        // POST: Facture/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                repFacture.Supprimer(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
