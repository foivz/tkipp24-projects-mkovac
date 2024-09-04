using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection.Emit;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class ForgotPasswordStepDefinitions
    {

        [AfterScenario]
        public void CloseApplication()
        {
            GuiDriver.Dispose();
        }

        [Given(@"Korisnik sam aplikacije")]
        public void GivenKorisnikSamAplikacije()
        {
            bool istina = true;
            Assert.IsTrue(istina);
        }

        [Given(@"Učita se prozor za prijavu")]
        public void GivenUcitaSeProzorZaPrijavu()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var frmLogin = driver.FindElementByName("Login") != null;

            Assert.IsTrue(frmLogin);
        }

        [When(@"Kliknem na gumb Forgot password\?")]
        public void WhenKliknemNaGumbForgotPassword()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnLogin = driver.FindElementByAccessibilityId("btnLogin");

            btnLogin.Click(); 
        }

        [When(@"Vidim prozor za dohvaćanje lozinke")]
        public void WhenVidimProzorZaDohvacanjeLozinke()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var frmForgotPassword = driver.FindElementByName("ForgotPassword") != null;

            Assert.IsTrue(frmForgotPassword);
        }

        [Then(@"Vidim tekst Email")]
        public void ThenVidimTekstEmail()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var label = driver.FindElementByName("labelEmail");

            Assert.AreEqual("Email", label.Text);
        }

        [Then(@"Vidim polje za unos ispod teksta Email")]
        public void ThenVidimPoljeZaUnosIspodTekstaEmail()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var txtEmail = driver.FindElementByName("txtEmail");

            Assert.IsNotNull(txtEmail);
            Assert.IsTrue(txtEmail.Displayed);
        }

        [Then(@"Vidim gumb Send ispod polja za unos")]
        public void ThenVidimGumbSendIspodPoljaZaUnos()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnSend = driver.FindElementByName("btnSend");

            Assert.IsNotNull(btnSend);
            Assert.IsTrue(btnSend.Displayed);
        }

        [Given(@"Odaberem polje za unos")]
        public void GivenOdaberemPoljeZaUnos()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var txtEmail = driver.FindElementByName("txtEmail");

            txtEmail.Click();
        }

        [Then(@"Unesem bilo koji tekst")]
        public void ThenUnesemBiloKojiTekst()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var txtEmail = driver.FindElementByName("txtEmail");
            txtEmail.SendKeys("tekst");
        }

        [Given(@"Unesem mail kojemu imam pristup")]
        public void GivenUnesemMailKojemuImamPristup()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var txtEmail = driver.FindElementByName("txtEmail");
            txtEmail.SendKeys("martakovac73@gmail.com");
        }

        [Given(@"Kliknem Send")]
        public void GivenKliknemSend()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnSend = driver.FindElementByName("btnSend");

            btnSend.Click();
        }

        [Then(@"Skočni prozor se prikazuje s porukom za uspješno slanje ""([^""]*)""")]
        public void ThenSkocniProzorSePrikazujeSPorukomZaUspjesnoSlanje(string p0)
        {
            throw new PendingStepException();
        }

        [Given(@"Unesem bilo koji mail koji se ne nalazi u bazi podataka")]
        public void GivenUnesemBiloKojiMailKojiSeNeNalaziUBaziPodataka()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var txtEmail = driver.FindElementByName("txtEmail");
            txtEmail.SendKeys("martakovac@gmail.com");
        }

        [Then(@"Skočni prozor se prikazuje s porukom za nepostojeći mail ""([^""]*)""")]
        public void ThenSkocniProzorSePrikazujeSPorukomZaNepostojeciMail(string p0)
        {
            throw new PendingStepException();
        }

        [Given(@"Unesem bilo koji mail bez @gmail\.com")]
        public void GivenUnesemBiloKojiMailBezGmail_Com()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var txtEmail = driver.FindElementByName("txtEmail");
            txtEmail.SendKeys("martakovac");
        }

        [Then(@"Skočni prozor se prikazuje s porukom  za neispavano unesen mail ""([^""]*)""")]
        public void ThenSkocniProzorSePrikazujeSPorukomZaNeispavanoUnesenMail(string p0)
        {
            throw new PendingStepException();
        }
    }
}
