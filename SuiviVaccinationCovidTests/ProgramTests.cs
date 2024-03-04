using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuiviVaccinationCovid;
using SuiviVaccinationCovid.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuiviVaccinationCovid.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void LePlusRecentTest()
        {
            List<Vaccin> vaccins = new List<Vaccin> {
                new Vaccin { Nom = "Pfizer" },
                new Vaccin { Nom = "Moderna" }
            };

            List<Dose> doses = new List<Dose>
            {
                new Dose
                {
                    NAMPatient = "AAAA10101010",
                    Vaccin = vaccins[0],
                    Date = new DateTime(2021,11,21)
                },
                new Dose
                {
                    NAMPatient = "BBBB10101010",
                    Vaccin = vaccins[0],
                    Date = new DateTime(2021,11,30)
                },
                new Dose
                {
                    NAMPatient = "CCCC10101010",
                    Vaccin = vaccins[1],
                    Date = new DateTime(2021,11,2)
                }
            };

            Dose reponse = new Dose
            {
                 NAMPatient = "BBBB10101010",
                 Vaccin = vaccins[0],
                 Date = new DateTime(2021, 11, 30)
            };
            Assert.AreEqual(reponse, Program.LePlusRecent(doses.AsQueryable<Dose>()));
        }

    }
}