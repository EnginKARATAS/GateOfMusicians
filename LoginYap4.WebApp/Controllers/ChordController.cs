using LoginYap4.BusinessLayer;
using LoginYap4.Entities;
using LoginYap4.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;

namespace LoginYap4.WebApp.Controllers
{
    public class ChordController : Controller
    {
        SongManager song = new SongManager();
        // GET: Chord
        public ActionResult UserChordInput(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View();
        }
    }
}