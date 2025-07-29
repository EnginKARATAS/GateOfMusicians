using LoginYap4.BusinessLayer;
using LoginYap4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LoginYap4.WebApp.Controllers
{
    public class SiteuserController : Controller
    {
        private SiteUserManager SiteUserManager = new SiteUserManager();


        public ActionResult Index()
        {
            return View(SiteUserManager.List());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SiteUser SiteUser = SiteUserManager.Find(x => x.Id == id.Value);

            if (SiteUser == null)
            {
                return HttpNotFound();
            }

            return View(SiteUser);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SiteUser SiteUser)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");

            if (ModelState.IsValid)
            {
                BusinessLayerResult<SiteUser> res = SiteUserManager.Insert(SiteUser);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(SiteUser);
                }

                return RedirectToAction("Index");
            }

            return View(SiteUser);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SiteUser SiteUser = SiteUserManager.Find(x => x.Id == id.Value);

            if (SiteUser == null)
            {
                return HttpNotFound();
            }

            return View(SiteUser);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SiteUser SiteUser)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");

            if (ModelState.IsValid)
            {
                BusinessLayerResult<SiteUser> res = SiteUserManager.Update(SiteUser);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(SiteUser);
                }

                return RedirectToAction("Index");
            }
            return View(SiteUser);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SiteUser SiteUser = SiteUserManager.Find(x => x.Id == id.Value);

            if (SiteUser == null)
            {
                return HttpNotFound();
            }

            return View(SiteUser);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiteUser SiteUser = SiteUserManager.Find(x => x.Id == id);
            SiteUserManager.Delete(SiteUser);

            return RedirectToAction("Index");
        }
    }
}
