using AncestryExercise.Helpers;
using AncestryExercise.Models;
using AncestryExercise.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AncestryExercise.Controllers
{
    public class PeepsController : Controller
    {
        //
        // GET: /Peeps/

        public ActionResult Index()
        {
            List<Peep> peeps = DataHelper.GetPeeps();

            return View(peeps);
        }

        public ActionResult Narrative(int id)
        {
            List<Peep> peeps = DataHelper.GetPeeps();

            Peep main = peeps.Where(p => p.PersonId == id).Single();
            Peep mom = peeps.Find(p => p.PersonId == main.MotherPersonId);
            Peep dad = peeps.Find(p => p.PersonId == main.FatherPersonId);
            List<Peep> wives = peeps.FindAll(p => main.WivesPersonIds.Contains(p.PersonId));
            List<Peep> husbands = peeps.FindAll(p => main.HusbandsPersonIds.Contains(p.PersonId));
            List<Peep> kids = peeps.FindAll(p => main.ChildrenPersonIds.Contains(p.PersonId));
            Narrative n = new Narrative
            {
                Main = main,
                Mom = mom,
                Dad = dad,
                Wives = wives,
                Husbands = husbands,
                Kids = kids
            };

            return View(n);
        }

    }
}
