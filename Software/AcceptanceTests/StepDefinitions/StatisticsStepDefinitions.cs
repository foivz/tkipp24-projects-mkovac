using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class StatisticsStepDefinitions
    {
        [AfterScenario]
        public void CloseApplication()
        {
            GuiDriver.Dispose();
        }

        [Given(@"Korisnik sam koji je prijavljen u sustav kao Admin")]
        public void GivenKorisnikSamKojiJePrijavljenUSustavKaoAdmin()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var txtUsername = driver.FindElementByAccessibilityId("txtUsername");
            var txtPassword = driver.FindElementByAccessibilityId("txtPassword");
            var btnLogin = driver.FindElementByAccessibilityId("btnLogin");

            txtUsername.SendKeys("admin");
            txtPassword.SendKeys("rpp");

            btnLogin.Click();

            var btnOk = driver.FindElementByAccessibilityId("2");
            btnOk.Click();
            System.Threading.Thread.Sleep(1000);
        }

        [When(@"Kliknem na karticu Statistics")]
        public void WhenKliknemNaKarticuStatistics()
        {
            var driver = GuiDriver.GetOrCreateDriver();

            var windowHandles = driver.WindowHandles;
            foreach (var handle in windowHandles)
            {
                driver.SwitchTo().Window(handle);
            }

            var btnStatistics = driver.FindElementByAccessibilityId("btnChildrenAttendance");

            btnStatistics.Click();
        }

        [Then(@"Vidim karticu Children Attendance")]
        public void ThenVidimKarticuChildrenAttendance()
        {
            throw new PendingStepException();
        }

        [Then(@"Vidim karticu Children Gender")]
        public void ThenVidimKarticuChildrenGender()
        {
            throw new PendingStepException();
        }

        [Then(@"Vidim karticu Children Groups")]
        public void ThenVidimKarticuChildrenGroups()
        {
            throw new PendingStepException();
        }

        [Given(@"Kliknem na karticu Children Attendance")]
        public void GivenKliknemNaKarticuChildrenAttendance()
        {
            throw new PendingStepException();
        }

        [Then(@"Vidim padajući izbornik na vrhu stranice")]
        public void ThenVidimPadajuciIzbornikNaVrhuStranice()
        {
            throw new PendingStepException();
        }

        [Then(@"Vidim Select a year ispred padajućeg izbornika")]
        public void ThenVidimSelectAYearIspredPadajucegIzbornika()
        {
            throw new PendingStepException();
        }

        [Given(@"Kliknem na karticu Children Gender")]
        public void GivenKliknemNaKarticuChildrenGender()
        {
            throw new PendingStepException();
        }

        [Then(@"Vidim graf koji je popunjen sa vrijednostima")]
        public void ThenVidimGrafKojiJePopunjenSaVrijednostima()
        {
            throw new PendingStepException();
        }

        [Then(@"Vrijednosti su u skladu s bazom podataka")]
        public void ThenVrijednostiSuUSkladuSBazomPodataka()
        {
            throw new PendingStepException();
        }

        [Given(@"Kliknem na karticu Children Groups")]
        public void GivenKliknemNaKarticuChildrenGroups()
        {
            throw new PendingStepException();
        }
    }
}
