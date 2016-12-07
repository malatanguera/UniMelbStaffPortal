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
    public class ITServices
    {
        //URL for service portal https://unimelbuat.service-now.com/it

        private readonly IWebDriver driver;

        //declare the elements

        [FindsBy(How = How.XPath, Using = ".//*[@id='it']/a/div")]
        private IWebElement InformationTechnologyLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//h1[contains(.,'IT Services')]")]
        private IWebElement ITHeaderText { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@ng-href='/it']")]
        private IWebElement ITBreadcrumb { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@alt='The University of Melbourne Logo']")]
        private IWebElement ITHeaderLogo { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Chat with us')]")]
        private IWebElement ITChatButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Service Centre (+61 3 834 40888)')]")]
        private IWebElement ITServiceCentre { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@src='https://d2h9b02ioca40d.cloudfront.net/shared/assets/lockup.png']")]
        private IWebElement ITFooterLogo { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Tour the page')]")]
        private IWebElement ITTourLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Page feedback?')]")]
        private IWebElement ITPageFeedbackLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@ng-click='toggleSearch()']")]
        private IWebElement ITSearchLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'?id=notices')]")]
        private IWebElement ITNoticesLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'profile_text')]")]
        private IWebElement ITProfileLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='?id=requests']")]
        private IWebElement ITTicketsLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@ng-click='menuClick()']")]
        private IWebElement ITMenuLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Staff Hub')]")]
        private IWebElement ITMenuStaffHubLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Logout')]")]
        private IWebElement ITMenuLogoutLink { get; set; }


        // IT Services buttons
        [FindsBy(How = How.XPath, Using = ".//*[@id='fix']/div")]
        private IWebElement FixLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='request']/div")]
        private IWebElement RequestLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='learn']/div")]
        private IWebElement LearnLink { get; set; }


        // Fix Something buttons (goes directly to forms)
        [FindsBy(How = How.XPath, Using = ".//*[@id='action']/div/div/div/ul/li[1]/a/div/div")]
        private IWebElement FixEmailLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x683aa2794f6d26007861a90f0310c7eb']/div/div/ul/li[2]/a/div/div")]
        private IWebElement FixComputerLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x683aa2794f6d26007861a90f0310c7eb']/div/div/ul/li[3]/a/div/div")]
        private IWebElement FixSoftwareLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x683aa2794f6d26007861a90f0310c7eb']/div/div/ul/li[4]/a/div/div")]
        private IWebElement FixPhoneLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x683aa2794f6d26007861a90f0310c7eb']/div/div/ul/li[5]/a/div/div")]
        private IWebElement FixPrintLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x683aa2794f6d26007861a90f0310c7eb']/div/div/ul/li[6]/a/div/div")]
        private IWebElement FixThemisLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x683aa2794f6d26007861a90f0310c7eb']/div/div/ul/li[7]/a/div/div")]
        private IWebElement FixABSLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x683aa2794f6d26007861a90f0310c7eb']/div/div/ul/li[8]/a/div")]
        private IWebElement FixWebpageLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x683aa2794f6d26007861a90f0310c7eb']/div/div/ul/li[9]/a/div/div")]
        private IWebElement FixElseLink { get; set; }


        // Request Something buttons

        // Request Something - Access the IT Network
        [FindsBy(How = How.XPath, Using = "//*[@id=\"action\"]/div/div/div/div[1]/div[1]/div/a")]
        private IWebElement ReqAccessNetworkLink { get; set; }

            //Access the IT Network -- forms
        [FindsBy(How = How.XPath, Using = ".//*[@id='x03dac5824fdd26007861a90f0310c7e8']/div/div/div/div[1]/div/a/div/h4")]
        private IWebElement ReqFileShareForm { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x03dac5824fdd26007861a90f0310c7e8']/div/div/div/div[2]/div/a/div/h4")]
        private IWebElement ReqSharedMailboxForm { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x03dac5824fdd26007861a90f0310c7e8']/div/div/div/div[3]/div/a/div/h4")]
        private IWebElement ReqAdviceForm { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x03dac5824fdd26007861a90f0310c7e8']/div/div/div/div[4]/div/a/div/h4")]
        private IWebElement ReqVisitorAccessForm { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x03dac5824fdd26007861a90f0310c7e8']/div/div/div/div[5]/div/a/div")]
        private IWebElement ReqStaffEmailForm { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x03dac5824fdd26007861a90f0310c7e8']/div/div/div/div[6]/div/a/div")]
        private IWebElement ReqEmailAliasForm { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x03dac5824fdd26007861a90f0310c7e8']/div/div/div/div[7]/div/a/div/div")]
        private IWebElement ReqGenericAcctForm { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x03dac5824fdd26007861a90f0310c7e8']/div/div/div/div[8]/div/a/div/div")]
        private IWebElement ReqExtensionForm { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x03dac5824fdd26007861a90f0310c7e8']/div/div/div/div[9]/div/a/div/div")]
        private IWebElement ReqStudentEmailForm { get; set; }


        // Access University Systems -- forms
        [FindsBy(How = How.XPath, Using = ".//*[@id='x76381c754f5926007861a90f0310c796']/div/div/div[1]/div[2]/div/a/div")]
        //  alternative xpath //*[@id="x76381c754f5926007861a90f0310c796"]/div/div/div[1]/div[2]/div/a/div/h3
        private IWebElement ReqUniSystemsLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x03dac5824fdd26007861a90f0310c7e8']/div/div/div/div[1]/div/a/div/h4")]
        private IWebElement ReqThemisHowForm { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x03dac5824fdd26007861a90f0310c7e8']/div/div/div/div[2]/div/a/div/h4")]
        private IWebElement ReqGLForm { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x03dac5824fdd26007861a90f0310c7e8']/div/div/div/div[3]/div/a/div/h4")]
        private IWebElement ReqThemisReportForm { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x03dac5824fdd26007861a90f0310c7e8']/div/div/div/div[4]/div/a/div/div")]
        private IWebElement ReqGenericRequestForm { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x03dac5824fdd26007861a90f0310c7e8']/div/div/div/div[6]/div/a/div/div")]
        private IWebElement ReqBIRForm { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x03dac5824fdd26007861a90f0310c7e8']/div/div/div/div[7]/div/a/div/div")]
        private IWebElement ReqKeyRoleChangesForm { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x03dac5824fdd26007861a90f0310c7e8']/div/div/div/div[8]/div/a/div/div")]
        private IWebElement ReqStudentOneForm { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x03dac5824fdd26007861a90f0310c7e8']/div/div/div/div[9]/div/a/div")]
        private IWebElement ReqThemisPrinterForm { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x03dac5824fdd26007861a90f0310c7e8']/div/div/div/div[10]/div/a/div/h4")]
        private IWebElement ReqWebPaymentForm { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x03dac5824fdd26007861a90f0310c7e8']/div/div/div/div[11]/div/a/div/div")]
        private IWebElement ReqThemisRoleForm { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x03dac5824fdd26007861a90f0310c7e8']/div/div/div/div[12]/div/a/div/h4")]
        private IWebElement ReqSASForm { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x03dac5824fdd26007861a90f0310c7e8']/div/div/div/div[13]/div/a/div/h4")]
        private IWebElement ReqRightNowForm { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x03dac5824fdd26007861a90f0310c7e8']/div/div/div/div[14]/div/a/div/h4")]
        private IWebElement ReqReapplyForm { get; set; }





        [FindsBy(How = How.XPath, Using = ".//*[@id='x76381c754f5926007861a90f0310c796']/div/div/div[1]/div[3]/div/a/div")]
        private IWebElement ReqComputersLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x76381c754f5926007861a90f0310c796']/div/div/div[1]/div[4]/div/a/div/p")]
        private IWebElement ReqPhonesLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x76381c754f5926007861a90f0310c796']/div/div/div[1]/div[5]/div/a/div/p")]
        private IWebElement ReqRelocationLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x76381c754f5926007861a90f0310c796']/div/div/div[1]/div[6]/div/a/div/h3")]
        private IWebElement ReqResearchLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='x76381c754f5926007861a90f0310c796']/div/div/div[1]/div[7]/div/a/div/h3")]
        private IWebElement ReqSpecialistLink { get; set; }


        






        public ITServices(IWebDriver driver)
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

        // Breadcrumbs - returning to menu pages
        public void ClickOnITServices()
        {
            IWebElement itServices = driver.FindElement(By.LinkText("IT Services"));
            itServices.Click();
            Thread.Sleep(3000);
        }

        public void ClickOnFixSomething()
        {
            IWebElement FixSomething = driver.FindElement(By.LinkText("Fix Something"));
            FixSomething.Click();
            Thread.Sleep(3000);
        }

        public void ClickOnRequestSomething()
        {
            IWebElement ReqSomething = driver.FindElement(By.LinkText("Request Something"));
            ReqSomething.Click();
            Thread.Sleep(3000);
        }

        public void ClickOnAccessTheITNetwork()
        {
            IWebElement AccessTheITNetwork = driver.FindElement(By.LinkText("Access the IT network"));
            AccessTheITNetwork.Click();
            Thread.Sleep(3000);
        }

        public void ClickOnAccessUniversitySystems()
        {
            IWebElement AccessUniversitySystems = driver.FindElement(By.LinkText("Access University Systems"));
            AccessUniversitySystems.Click();
            Thread.Sleep(3000);
        }

        public void ClickOnComputersPrintingAndSoftware()
        {
            IWebElement ComputersPrintingAndSoftware = driver.FindElement(By.LinkText("Computers, printing and software"));
            ComputersPrintingAndSoftware.Click();
            Thread.Sleep(3000);
        }

        public void ClickOnPhones()
        {
            IWebElement Phones = driver.FindElement(By.LinkText("Phones"));
            Phones.Click();
            Thread.Sleep(3000);
        }

        public void ClickOnRelocation()
        {
            IWebElement Relocation = driver.FindElement(By.LinkText("Relocation"));
            Relocation.Click();
            Thread.Sleep(3000);
        }

        public void ClickOnResearchTechnology()
        {
            IWebElement ResearchTechnology = driver.FindElement(By.LinkText("Research Technology"));
            ResearchTechnology.Click();
            Thread.Sleep(3000);
        }

        public void ClickOnSpecialistITServices()
        {
            IWebElement SpecialistITServices = driver.FindElement(By.LinkText("Specialist IT Services"));
            SpecialistITServices.Click();
            Thread.Sleep(3000);
        }






        // IT Services menu page buttons
        public void ClickAndVerifyFix()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            FixLink.Click();
            Thread.Sleep(6000);
            var textPresent = driver.PageSource.Contains("What does your problem relate to?");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyRequest()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            RequestLink.Click();
            Thread.Sleep(6000);
            var textPresent = driver.PageSource.Contains("What service or item do you need?");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyLearn()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            LearnLink.Click();
            Thread.Sleep(6000);
            var textPresent = driver.PageSource.Contains("What topic would you like to learn more about?");
            Assert.IsTrue(textPresent);
        }


        // Fix Something menu page buttons, which are also the form links because Fix Something has one fewer level than Request Something
        public void ClickAndVerifyEmail()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            FixEmailLink.Click();
            Thread.Sleep(2000);
            var textPresent = driver.PageSource.Contains("Email and Calendar");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyComputer()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            FixComputerLink.Click();
            Thread.Sleep(2000);
            var textPresent = driver.PageSource.Contains("Computer/Network");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifySoftware()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            FixSoftwareLink.Click();
            Thread.Sleep(2000);
            var textPresent = driver.PageSource.Contains("Software");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyPhone()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            FixPhoneLink.Click();
            Thread.Sleep(2000);
            var textPresent = driver.PageSource.Contains("Telephone");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyPrinting()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            FixPrintLink.Click();
            Thread.Sleep(2000);
            var textPresent = driver.PageSource.Contains("Printing");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyThemis()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            FixThemisLink.Click();
            Thread.Sleep(2000);
            var textPresent = driver.PageSource.Contains("Themis");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyABS()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            FixABSLink.Click();
            Thread.Sleep(2000);
            var textPresent = driver.PageSource.Contains("Academic Business Systems");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyWebpage()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            FixWebpageLink.Click();
            Thread.Sleep(2000);
            var textPresent = driver.PageSource.Contains("Webpage/Application");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyElse()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            FixElseLink.Click();
            Thread.Sleep(2000);
            var textPresent = driver.PageSource.Contains("Something else...");
            Assert.IsTrue(textPresent);
        }


        // Request Something Buttons - Access the IT Network forms
        public void ClickAndVerifyAccessNetwork()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            ReqAccessNetworkLink.Click();
            Thread.Sleep(6000);
            //var textPresent = driver.PageSource.Contains("What topic would you like to learn more about?");
            //Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyFileShare()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            ReqFileShareForm.Click();
            Thread.Sleep(2000);
            var textPresent = driver.PageSource.Contains("File share (shared folders)");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifySharedMailbox()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            ReqSharedMailboxForm.Click();
            Thread.Sleep(1000);
            var textPresent = driver.PageSource.Contains("Shared mailbox");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyNetworkAdvice()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            ReqAdviceForm.Click();
            Thread.Sleep(1000);
            var textPresent = driver.PageSource.Contains("Network - Advice or assistance");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyVisitorAccess()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            ReqVisitorAccessForm.Click();
            Thread.Sleep(1000);
            var textPresent = driver.PageSource.Contains("Network - Visitor access");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyStaffEmail()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            ReqStaffEmailForm.Click();
            Thread.Sleep(1000);
            var textPresent = driver.PageSource.Contains("Staff email enquiry");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyEmailAlias()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            ReqEmailAliasForm.Click();
            Thread.Sleep(1000);
            var textPresent = driver.PageSource.Contains("Email alias");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyGenericAcct()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            ReqGenericAcctForm.Click();
            Thread.Sleep(1000);
            var textPresent = driver.PageSource.Contains("Generic Account");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyExtension()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            ReqExtensionForm.Click();
            Thread.Sleep(1000);
            var textPresent = driver.PageSource.Contains("IT access - Extension or re-enable");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyStudentEmail()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            ReqStudentEmailForm.Click();
            Thread.Sleep(1000);
            var textPresent = driver.PageSource.Contains("Student email account update");
            Assert.IsTrue(textPresent);
        }


        //Request Something buttons - Access University Systems forms
        public void ClickAndVerifyAccessUniSys()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            ReqUniSystemsLink.Click();
            Thread.Sleep(6000);
            var textPresent = driver.PageSource.Contains("Access University Systems");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyThemisHow()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            ReqThemisHowForm.Click();
            Thread.Sleep(1000);
            var textPresent = driver.PageSource.Contains("Themis 'How do I...' enquiry");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyGL()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            ReqGLForm.Click();
            Thread.Sleep(1000);
            var textPresent = driver.PageSource.Contains("GL account validation");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyThemisReport()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            ReqThemisReportForm.Click();
            Thread.Sleep(1000);
            var textPresent = driver.PageSource.Contains("Themis - Report request");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyGenericRequest()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            ReqGenericRequestForm.Click();
            Thread.Sleep(1000);
            var textPresent = driver.PageSource.Contains("Generic Request");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyBIR()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            ReqBIRForm.Click();
            Thread.Sleep(1000);
            var textPresent = driver.PageSource.Contains("Business intelligence and reporting");
            Assert.IsTrue(textPresent);
        }

        public void ClickAndVerifyKeyRoleChange()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            ReqKeyRoleChangesForm.Click();
            Thread.Sleep(1000);
            var textPresent = driver.PageSource.Contains("Key organisational role changes");
            Assert.IsTrue(textPresent);
        }



    }
}
