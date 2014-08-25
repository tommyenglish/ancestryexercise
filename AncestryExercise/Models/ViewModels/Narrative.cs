using AncestryExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AncestryExercise.ViewModels
{
    public class Narrative
    {
        public Peep Main { get; set; }
        public Peep Mom { get; set; }
        public Peep Dad { get; set; }
        public List<Peep> Husbands { get; set; }
        public List<Peep> Wives { get; set; }
        public List<Peep> Kids { get; set; }
    }
}