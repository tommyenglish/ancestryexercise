using AncestryExercise.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AncestryExercise.Helpers
{
    // this class mirrors the settings from the tsv file.
    // this way, the csvhelper can bring it in without custom mapping.
    // personId	givenName	surname	birthplace	birthyear	deathplace	deathyear	fatherPersonId	motherPersonId	childrenPersonIds	wivesPersonIds	husbandsPersonIds
    class AncestryPeep
    {
        public int personId { get; set; }
        public string givenName { get; set; }
        public string surname { get; set; }
        public string birthplace { get; set; }
        public string birthyear { get; set; }
        public string deathplace { get; set; }
        public string deathyear { get; set; }
        public string fatherPersonId { get; set; }
        public string motherPersonId { get; set; }
        public string childrenPersonIds { get; set; }
        public string wivesPersonIds { get; set; }
        public string husbandsPersonIds { get; set; }
    }

    public static class DataHelper
    {
        private static List<Peep> peeps = new List<Peep>();

        public static List<Peep> GetPeeps()
        {
            return peeps;
        }

        public static Peep GetPeep(int id)
        {
            return peeps.Find(p => p.PersonId == id);
        }

        public static void LoadPeeps(string filepath)
        {
            peeps.Clear();

            List<AncestryPeep> ancestryPeeps = new List<AncestryPeep>();

            using (StreamReader reader = new StreamReader(filepath))
            {
                var csv = new CsvReader(reader);
                csv.Configuration.Delimiter = "\t";
                ancestryPeeps = csv.GetRecords<AncestryPeep>().ToList();
            }

            generatePeeps(ancestryPeeps);
        }

        private static void generatePeeps(List<AncestryPeep> ancestryPeeps)
        {
            int temp;
            foreach (var item in ancestryPeeps)
            {
                Peep p = new Peep();
                p.PersonId = item.personId;
                p.GivenName = item.givenName;
                p.Surname = item.surname;
                p.Birthplace = item.birthplace;
                p.BirthYear = int.TryParse(item.birthyear, out temp) ? temp : (int?)null;
                p.DeathPlace = item.deathplace;
                p.DeathYear = int.TryParse(item.deathyear, out temp) ? temp : (int?)null;
                p.FatherPersonId = int.TryParse(item.fatherPersonId, out temp) ? temp : (int?)null;
                p.MotherPersonId = int.TryParse(item.motherPersonId, out temp) ? temp : (int?)null;
                p.ChildrenPersonIds = generateIdList(item.childrenPersonIds);
                p.WivesPersonIds = generateIdList(item.wivesPersonIds);
                p.HusbandsPersonIds = generateIdList(item.husbandsPersonIds);

                peeps.Add(p);
            }
        }

        private static List<int> generateIdList(string ids)
        {
            List<int> list = new List<int>();

            if (ids.Length > 0)
            {
                List<string> idList = ids.Split(',').ToList<string>();
                

                foreach (var id in idList)
                {
                    list.Add((int.Parse(id)));
                }
            }

            return list;
        }
    }
}