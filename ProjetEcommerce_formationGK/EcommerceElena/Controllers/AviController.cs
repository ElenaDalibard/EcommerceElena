using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceElena.DataAccess;
using EcommerceElena.Models;
using EcommerceElena.Outils;

namespace EcommerceElena.Controllers
{
    public class AviController : Controller
    {
        Repository<Avi> repAvi = new EFRepository<Avi>();

        // GET: Avi
        [Authorize]
        public ActionResult Index()
        {
            return View(repAvi.Lister().OrderByDescending(a=>a.statusAvis));
        }
        public ActionResult AvisNonAppr()
        {
            return View("Index", repAvi.Lister().Where(a=>a.statusAvis==(int)StatusAvis.nonapprouvé).OrderByDescending(a=>a.dateAvis));
        }

        public ActionResult AvisRefuse()
        {
            return View("Index", repAvi.Lister().Where(a => a.statusAvis == (int)StatusAvis.rejeté).OrderByDescending(a=>a.dateAvis));
        }


        // POST: Avi/Refuser/5
        [HttpPost]
        public ContentResult Refuser(int id)
        {
            Avi aviRefuse = repAvi.Trouver(id);
            aviRefuse.statusAvis = (int)StatusAvis.rejeté;
            repAvi.Modifier(aviRefuse);
            return new ContentResult
            {
                Content = ((StatusAvis)aviRefuse.statusAvis).ToString()
            };
        }

        public ContentResult Approuver(int id)
        {
            Avi avisApprouve = repAvi.Trouver(id);
            avisApprouve.statusAvis = (int)StatusAvis.approuvé;
            repAvi.Modifier(avisApprouve);
            return new ContentResult
            {
                Content = ((StatusAvis)avisApprouve.statusAvis).ToString()
            };
        }


        // POST: Avi/Delete/5
        public ContentResult Delete(int id)
        {
                repAvi.Supprimer(id);
                return new ContentResult();
        }
    }
}
