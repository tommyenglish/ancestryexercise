using AncestryExercise.Models;
using AncestryExercise.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AncestryExercise.Helpers
{
    public static class MomHelper
    {
        public static List<MomAge> GetYoungestMoms(List<Peep> moms)
        {
            List<MomAge> momAgeList = new List<MomAge>();

            foreach (var mom in moms)
            {
                foreach (var kidId in mom.ChildrenPersonIds)
                {
                    var kid = DataHelper.GetPeep(kidId);

                    if (kid.BirthYear.HasValue)
                    {
                        var item = new MomAge{mom = mom, age = (int)kid.BirthYear - (int)mom.BirthYear};
                        momAgeList.Add(item);
                    }
                }
            }

            return momAgeList.OrderBy(p => p.age).Take(3).ToList();
        }
    }
}