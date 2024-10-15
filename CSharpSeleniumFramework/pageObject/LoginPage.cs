using CSharpSeleniumFramework.utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumFramework.pageObject
{
    class LoginPage
    {
        private IWebDriver driver;
        private string Username;
        private string Password;
        public LoginPage(IWebDriver driver, string username, string password)
        {
            this.driver = driver;
            Username = username;
            Password = password;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".ico-login")]
        private IWebElement homeLoginBtn;
        public IWebElement getHomeLoginBtn()
        {
            return homeLoginBtn;
        }

        [FindsBy(How = How.CssSelector, Using = "div[class='page-title']")]
        private IWebElement loginPageTitleMessage;
        public IWebElement getLoginPageTitleMessage()
        {
            return loginPageTitleMessage;
        }

        //h1[normalize-space()='Welcome, Please Sign In!']

        [FindsBy(How = How.XPath, Using = "//input[@id='Email']")]
        private IWebElement userId;
        public IWebElement getUserId()
        {
            return userId;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='Password']")]
        private IWebElement password;
        public IWebElement getPassword()
        {
            return password;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='RememberMe']")]
        private IWebElement rememberCheckBox;
        public IWebElement getRememberCheckBox()
        {
            return rememberCheckBox;
        }

        [FindsBy(How = How.XPath, Using = "//input[@value='Log in']")]
        private IWebElement loginBtn;
        public IWebElement getLoginBtn()
        {
            return loginBtn;
        }

        public HomePageLoggedIn validLogin()
        {
            homeLoginBtn.Click();
            userId.SendKeys(Username);
            password.SendKeys(Password);
            rememberCheckBox.Click();
            loginBtn.Click();
            return new HomePageLoggedIn(driver);
        }

        [FindsBy(How = How.CssSelector, Using = ".ico-logout")]
        private IWebElement logOutBtn;
        public IWebElement getLogOutBtn()
        {
            return logOutBtn;
        }

    }
}
