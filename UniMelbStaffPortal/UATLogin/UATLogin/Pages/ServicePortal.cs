using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UATLogin.Pages;
using System.Threading;
using System.Configuration;

namespace UATLogin.Pages
{
    public class ServicePortal
    {
        //URL for service portal https://unimelbuat.service-now.com/sp 

        private readonly IWebDriver driver;

        //declare the elements

        [FindsBy(How = How.XPath, Using = "//h1[@id='staff_services']")]
        private IWebElement SPHeaderText { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Staff Services')]")]
        private IWebElement SPBreadcrumb { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@alt='The University of Melbourne Logo']")]
        private IWebElement SPHeaderLogo { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[contains(@src,'https://d2h9b02ioca40d.cloudfront.net/shared/assets/lockup.png')]")]
        private IWebElement SPFooterLogo { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Tour the page')]")]
        private IWebElement SPTourLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Page feedback?')]")]
        private IWebElement SPPageFeedbackLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,' Search ')]")]
        private IWebElement SPSearchLink { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'?id=notices')]")]
        private IWebElement SPNoticesLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'profile_text')]")]
        private IWebElement SPProfileLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Tickets')]")]
        private IWebElement SPTicketsLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@ng-click='menuClick()']")]
        private IWebElement SPMenuLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Staff Hub')]")]
        private IWebElement SPMenuStaffHubLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Logout')]")]
        private IWebElement SPMenuLogoutLink { get; set; }




        [FindsBy(How = How.XPath, Using = ".//*[@id='it']/a/div")]
        private IWebElement InformationTechnologyLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='services_row']/div[2]/div/a/div")]
        private IWebElement HumanResourcesLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='services_row']/div[3]/div/a/div")]
        private IWebElement CampusLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='services_row']/div[4]/div/a/div")]
        private IWebElement FinanceLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='services_row']/div[5]/div/a/div")]
        private IWebElement StudentsAndTeachingLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='services_row']/div[6]/div/a/div")]
        private IWebElement MarketingLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='services_row']/div[7]/div/a/div")]
        private IWebElement LegalLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='services_row']/div[8]/div/a/div")]
        private IWebElement LibraryLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='services_row']/div[9]/div/a/div")]
        private IWebElement ResearchLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='services_row']/div[10]/div/a/div")]
        private IWebElement NewStaffLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='services_row']/div[11]/div/a/div")]
        private IWebElement HealthSafetyLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='services_row']/div[12]/div/a/div")]
        private IWebElement DiversityLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='col-md-push-4']/a/div")]
        public IWebElement ImprovementsLink { get; set; }



        public ServicePortal(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void SwitchTo(string prefix)
        {
            var handlers = driver.WindowHandles;
            foreach (var handler in handlers)
            {
                driver.SwitchTo().Window(handler);
                if (driver.Url.Contains(prefix)) return;
            }
        }

        public void ClickAndVerifyInformationTechnology()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));
        
            InformationTechnologyLink.Click();
            Thread.Sleep(6000);
            var textPresent = driver.PageSource.Contains("IT Services");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyHumanResources()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));
         
            HumanResourcesLink.Click();
            Thread.Sleep(6000);
            var textPresent = driver.PageSource.Contains("HR Services");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyCampus()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            CampusLink.Click();
            Thread.Sleep(6000);
            var textPresent = driver.PageSource.Contains("Campus Services");
            Assert.IsTrue(textPresent);
        }

        //goes to an external page - how do I handle getting back? 
        //public void ClickAndVerifyFinance()
        //{
        //    driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

        //    FinanceLink.Click();
        //    Thread.Sleep(6000);
        //    var textPresent = driver.PageSource.Contains("Finance, purchasing and travel");
        //    Assert.IsTrue(textPresent);
        //}

        public void ClickAndVerifyStudentsAndTeaching()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            StudentsAndTeachingLink.Click();
            Thread.Sleep(6000);
            var textPresent = driver.PageSource.Contains("Student and Teaching Services");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyMarketing()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            MarketingLink.Click();
            Thread.Sleep(6000);
            var textPresent = driver.PageSource.Contains("Marketing and Communication Services");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyLegal()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            LegalLink.Click();
            Thread.Sleep(6000);
            var textPresent = driver.PageSource.Contains("Legal Services");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyLibrary()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            LibraryLink.Click();
            Thread.Sleep(6000);
            var textPresent = driver.PageSource.Contains("Library Services");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyResearch()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            ResearchLink.Click();
            Thread.Sleep(6000);
            var textPresent = driver.PageSource.Contains("Research Services");
            Assert.IsTrue(textPresent);
        }

        //New Staff, Health and Safety, Diversity, and Service Improvments all go to external links

         


        public void ClickOnStaffServices()
        {
            IWebElement staffServices = driver.FindElement(By.LinkText("Staff Services"));
            staffServices.Click();
            Thread.Sleep(3000);
        }






        public void VerifyText()
        {
            var textPresent = driver.PageSource.Contains("Staff Services");
            Assert.IsTrue(textPresent);

                        //add validations
        }
    }
}
