using AncestryExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AncestryExercise.ViewModels
{
    public class Stats
    {
        public double Mean { get; set; }
        public double Median { get; set; }
        public double Quartile25 { get; set; }
        public double Quartile75 { get; set; }
        public Awards Awards { get; set; }
    }

    public class Awards
    {
        public List<MomAge> YoungestMoms { get; set; }
        public List<MomAge> OldestMoms { get; set; }
        public List<Peep> Rabbits { get; set; }
        public List<Peep> CradleRobbers { get; set; }
    }

    public class MomAge
    {
        public Peep mom { get; set; }
        public int age { get; set; }
    }
}