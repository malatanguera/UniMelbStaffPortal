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
    public class HRServices
    {
        private readonly IWebDriver driver;

        //declare the elements

        [FindsBy(How = How.XPath, Using = ".//*[@id='it']/a/div")]
        private IWebElement InformationTechnologyLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='services_row']/div[2]/div/a/div")]
        private IWebElement HumanResourcesLink { get; set; }

        public HRServices(IWebDriver driver)
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
        public void ClickAndVerifyHumanResources()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(500));

            HumanResourcesLink.Click();
            Thread.Sleep(6000);
            var textPresent = driver.PageSource.Contains("HR Services");
            Assert.IsTrue(textPresent);
        }

        public void VerifyText()
        {
            //add validations
        }

        public void ClickOnHRServices()
        {
            IWebElement hrServices = driver.FindElement(By.LinkText("HR Services"));
            hrServices.Click();
            Thread.Sleep(3000);

        }

    }
}
