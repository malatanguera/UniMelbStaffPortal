using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UATLogin.DataAccess;

namespace UATLogin.Pages
{
    public class Login
    {

        private readonly IWebDriver driver;

        [FindsBy(How = How.Name, Using = "user_name")]
        private IWebElement UserName { get; set; }

        [FindsBy(How = How.Id, Using = "user_password")]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "sysverb_login")]
        private IWebElement Submit { get; set; }

        public Login(IWebDriver driver)
        {
            this.driver = driver;
           PageFactory.InitElements(driver, this);
        }

        public void LoginToServiceNow()
        {
            driver.Manage().Window.Maximize();
            driver.SwitchTo().DefaultContent();

            var user = new User();
            user = ExcelDataAccess.GetTestData("Login");

            UserName.SendKeys(user.UserName);

            Password.SendKeys(user.Password);

            Submit.Click();

        }
    }
}
