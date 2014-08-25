using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AncestryExercise.Models
{
    public class Peep
    {
        public int PersonId { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string Birthplace { get; set; }
        public int? BirthYear { get; set; }
        public string DeathPlace { get; set; }
        public int? DeathYear { get; set; }
        public int? FatherPersonId { get; set; }
        public int? MotherPersonId { get; set; }
        public List<int> ChildrenPersonIds { get; set; }
        public List<int> WivesPersonIds { get; set; }
        public List<int> HusbandsPersonIds { get; set; }

        // Some computed properties
        public double Age
        {
            get
            {
                if (this.DeathYear.HasValue && this.BirthYear.HasValue)
                {
                    return (int)this.DeathYear - (int)this.BirthYear;
                }
                else if (this.BirthYear.HasValue) // assume they're still alive if they have a birth year, but no death year, in which case use the current year
                {
                    return DateTime.Now.Year - (int)this.BirthYear;
                }
                else // assume data is missing, so just set to -1.
                { 
                    return -1; 
                }
            }
        }

        // Making an assumption here that if they have a wife, they're male and if they have a husband, they're female.
        // This is a bad assumption, especially in today's world, but it'll do.
        public string Gender
        {
            get
            {
                if (this.WivesPersonIds.Count > 0)
                {
                    return "Male";
                }
                else if (this.HusbandsPersonIds.Count > 0) 
                {
                    return "Female";
                }
                else 
                {
                    return "Unknown";
                }
            }
        }

        public string FullName
        {
            get
            {
                return String.Concat(this.GivenName, " ", this.Surname);
            }
        }
    }
}