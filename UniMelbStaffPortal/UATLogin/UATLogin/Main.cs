using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UATLogin.Pages;
using System.Threading;
using System.Configuration;

namespace UATLogin
{
    public class Main
    {
        IWebDriver driver;
        [SetUp]
        public void TestInit()
        {
            try
            {
                driver = new ChromeDriver();
            }
            catch (Exception e)
            {
            }
        }

        [Test]
        public void SPVerification()
        {
            try
            {
                driver.Url = ConfigurationManager.AppSettings["URL"];
                var loginPage = new Login(driver);
                loginPage.LoginToServiceNow();

                //navigating to SP
                IWebElement selfService = driver.FindElement(By.LinkText("Self-Service"));

                string className = selfService.GetAttribute("class");

                //driver.FindElement(By.LinkText("Self-Service"));
                if (className == "nav-app collapsed")
                    selfService.Click();              

                driver.FindElement(By.XPath("//a[@title='Staff Services Portal']")).Click();
                Thread.Sleep(1000);


                //call serviceportal -- click portal catalog, verify the title, return to Staff Services. Repeat. 
                var sp = new ServicePortal(driver);
                sp.VerifyText();
                sp.SwitchTo("https://unimelbuat.service-now.com/sp");
                driver.SwitchTo().DefaultContent();
                sp.ClickAndVerifyInformationTechnology();
                sp.ClickOnStaffServices();
                sp.ClickAndVerifyHumanResources();
                sp.ClickOnStaffServices();
                sp.ClickAndVerifyCampus();
                sp.ClickOnStaffServices();
                sp.ClickAndVerifyStudentsAndTeaching();
                sp.ClickOnStaffServices();
                sp.ClickAndVerifyMarketing();
                sp.ClickOnStaffServices();
                sp.ClickAndVerifyLegal();
                sp.ClickOnStaffServices();
                sp.ClickAndVerifyLibrary();
                sp.ClickOnStaffServices();
                sp.ClickAndVerifyResearch();
                sp.ClickOnStaffServices();
                

            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ITVerification()
        {
            try
            {
                driver.Url = ConfigurationManager.AppSettings["URL"];
                var loginPage = new Login(driver);
                loginPage.LoginToServiceNow();

                //navigating to SP
                IWebElement selfService = driver.FindElement(By.LinkText("Self-Service"));

                string className = selfService.GetAttribute("class");

                //driver.FindElement(By.LinkText("Self-Service"));
                if (className == "nav-app collapsed")
                    selfService.Click();

                driver.FindElement(By.XPath("//a[@title='Staff Services Portal']")).Click();
                Thread.Sleep(1000);


                //call serviceportal
                var sp = new ITServices(driver);
                sp.SwitchTo("https://unimelbuat.service-now.com/sp");
                driver.SwitchTo().DefaultContent();
                sp.ClickAndVerifyInformationTechnology();

                //Verify header, footer, tour, and page feedback 
                
                // Fix Something button
                sp.ClickAndVerifyFix();
                sp.ClickOnITServices();

                // Request Something button
                sp.ClickAndVerifyRequest();
                sp.ClickOnITServices();

                // Learn Something button
                sp.ClickAndVerifyLearn();
                sp.ClickOnITServices();

            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ITFixSomethingVerification()
        {
            try
            {
                driver.Url = ConfigurationManager.AppSettings["URL"];
                var loginPage = new Login(driver);
                loginPage.LoginToServiceNow();

                //navigating to SP
                IWebElement selfService = driver.FindElement(By.LinkText("Self-Service"));

                string className = selfService.GetAttribute("class");

                //driver.FindElement(By.LinkText("Self-Service"));
                if (className == "nav-app collapsed")
                    selfService.Click();

                driver.FindElement(By.XPath("//a[@title='Staff Services Portal']")).Click();
                Thread.Sleep(1000);


                //call serviceportal
                var sp = new ITServices(driver);
                sp.SwitchTo("https://unimelbuat.service-now.com/sp");
                driver.SwitchTo().DefaultContent();
                sp.ClickAndVerifyInformationTechnology();

                // Fix Something Branch
                sp.ClickAndVerifyFix();
                sp.ClickAndVerifyEmail();
                sp.ClickOnFixSomething();
                sp.ClickAndVerifyComputer();
                sp.ClickOnFixSomething();
                sp.ClickAndVerifySoftware();
                sp.ClickOnFixSomething();
                sp.ClickAndVerifyPhone();
                sp.ClickOnFixSomething();
                sp.ClickAndVerifyPrinting();
                sp.ClickOnFixSomething();
                sp.ClickAndVerifyThemis();
                sp.ClickOnFixSomething();
                sp.ClickAndVerifyABS();
                sp.ClickOnFixSomething();
                sp.ClickAndVerifyWebpage();
                sp.ClickOnFixSomething();
                sp.ClickAndVerifyElse();

                sp.ClickOnITServices();
              
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ITRequestSomethingVerification()
        {
            try
            {
                driver.Url = ConfigurationManager.AppSettings["URL"];
                var loginPage = new Login(driver);
                loginPage.LoginToServiceNow();

                //navigating to SP
                IWebElement selfService = driver.FindElement(By.LinkText("Self-Service"));

                string className = selfService.GetAttribute("class");

                //driver.FindElement(By.LinkText("Self-Service"));
                if (className == "nav-app collapsed")
                    selfService.Click();

                driver.FindElement(By.XPath("//a[@title='Staff Services Portal']")).Click();
                Thread.Sleep(1000);


                //call serviceportal
                var sp = new ITServices(driver);
                sp.SwitchTo("https://unimelbuat.service-now.com/sp");
                driver.SwitchTo().DefaultContent();
                sp.ClickAndVerifyInformationTechnology();

                // Request Something -- Access the IT Network
                sp.ClickAndVerifyRequest();
                sp.ClickAndVerifyAccessNetwork();
                sp.ClickAndVerifyFileShare();
                sp.ClickOnAccessTheITNetwork();
                sp.ClickAndVerifySharedMailbox();
                sp.ClickOnAccessTheITNetwork();
                sp.ClickAndVerifyNetworkAdvice();
                sp.ClickOnAccessTheITNetwork();
                sp.ClickAndVerifyVisitorAccess();
                sp.ClickOnAccessTheITNetwork();
                sp.ClickAndVerifyStaffEmail();
                sp.ClickOnAccessTheITNetwork();
                sp.ClickAndVerifyEmailAlias();
                sp.ClickOnAccessTheITNetwork();
                sp.ClickAndVerifyGenericAcct();
                sp.ClickOnAccessTheITNetwork();
                sp.ClickAndVerifyExtension();
                sp.ClickOnAccessTheITNetwork();
                sp.ClickAndVerifyStudentEmail();

                ////Access University Systems
                //sp.ClickOnRequestSomething();




            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ITLearnSomethingVerification()
        {
            try
            {
                driver.Url = ConfigurationManager.AppSettings["URL"];
                var loginPage = new Login(driver);
                loginPage.LoginToServiceNow();

                //navigating to SP
                IWebElement selfService = driver.FindElement(By.LinkText("Self-Service"));

                string className = selfService.GetAttribute("class");

                //driver.FindElement(By.LinkText("Self-Service"));
                if (className == "nav-app collapsed")
                    selfService.Click();

                driver.FindElement(By.XPath("//a[@title='Staff Services Portal']")).Click();
                Thread.Sleep(1000);


                //call serviceportal
                var sp = new ITServices(driver);
                sp.SwitchTo("https://unimelbuat.service-now.com/sp");
                driver.SwitchTo().DefaultContent();
                sp.ClickAndVerifyInformationTechnology();

                // Learn Something 
                sp.ClickAndVerifyLearn();
                sp.ClickOnITServices();

            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void HRVerification()
        {
            try
            {
                driver.Url = ConfigurationManager.AppSettings["URL"];
                var loginPage = new Login(driver);
                loginPage.LoginToServiceNow();

                //navigating to SP
                IWebElement selfService = driver.FindElement(By.LinkText("Self-Service"));

                string className = selfService.GetAttribute("class");

                //driver.FindElement(By.LinkText("Self-Service"));
                if (className == "nav-app collapsed")
                    selfService.Click();

                driver.FindElement(By.XPath("//a[@title='Staff Services Portal']")).Click();
                Thread.Sleep(1000);


                //call serviceportal
                var sp = new HRServices(driver);              
                sp.SwitchTo("https://unimelbuat.service-now.com/sp");
                driver.SwitchTo().DefaultContent();
                sp.ClickAndVerifyHumanResources();
                sp.ClickOnHRServices();
                //  sp.ClickAndVerifyCasualContracts();
                //  sp.ClickOnITServices();



            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [TearDown]
        public void TestCleanup()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }

        }
    }
}
