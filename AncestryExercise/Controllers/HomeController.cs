
using AncestryExercise.Helpers;
using AncestryExercise.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AncestryExercise.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // This loads the data to be used throughout the app.
            string filePath = Server.MapPath("~/Content/files/family.tsv");

            DataHelper.LoadPeeps(filePath);

            return View();
        }
    }
}
