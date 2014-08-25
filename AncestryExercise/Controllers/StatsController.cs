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
    public class StatsController : Controller
    {
        //
        // GET: /Stats/

        public ActionResult Index()
        {
            List<Peep> peeps = DataHelper.GetPeeps();
            double median = ListHelper.GetMedian(peeps.Where(p => p.Age != -1).Select(p => p.Age).ToList());
            double q25 = ListHelper.GetMedian(peeps.Where(p => p.Age != -1 && p.Age < median).Select(p => p.Age).ToList());
            double q75 = ListHelper.GetMedian(peeps.Where(p => p.Age != -1 && p.Age > median).Select(p => p.Age).ToList());
            List<Peep> moms = peeps.Where(p => p.Gender.Equals("Female") && p.Age != -1 && p.ChildrenPersonIds.Count > 0).ToList();

            Awards awards = new Awards
            {
                YoungestMoms = MomHelper.GetYoungestMoms(moms)
            };
            Stats stats = new Stats
            {
                Mean = peeps.Where(p => p.Age != -1).Average(p => p.Age),
                Median = median,
                Quartile25 = q25,
                Quartile75 = q75,
                Awards = awards    
            };
            return View(stats);
        }
    }
}