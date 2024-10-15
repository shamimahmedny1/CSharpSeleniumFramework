using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumFramework.pageObject
{
    class UserRegistrationPage
    {
        private IWebDriver driver;
        public UserRegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".ico-register")]
        private IWebElement mainRegistrationBtn;
        public void getMainRegistrationBtn()
        {
            mainRegistrationBtn.Click();
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='gender-male']")]
        private IWebElement maleRadioBtn;
        public void getMaleRadioBtn()
        {
            maleRadioBtn.Click();
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='gender-female']")]
        private IWebElement femaleRadioBtn;
        public void getFemaleRadioBtn()
        {
            femaleRadioBtn.Click();
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='FirstName']")]
        private IWebElement firstName;
        public IWebElement getFirstName()
        {
            return firstName;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='LastName']")]
        private IWebElement lasttName;
        public IWebElement getLastName()
        {
            return lasttName;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='Email']")]
        private IWebElement email;
        public IWebElement getEmail()
        {
            return email;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='Password']")]
        private IWebElement password;
        public IWebElement getPassword()
        {
            return password;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='ConfirmPassword']")]
        private IWebElement confirmPassword;
        public IWebElement getConfirmPassword()
        {
            return confirmPassword;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='register-button']")]
        private IWebElement registerBtn;
        public void getRegisterBtn()
        {
            registerBtn.Click();
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='result']")]
        private IWebElement registrationConfirmationMessage;
        public IWebElement getRegistrationConfirmationMessage()
        {
            return registrationConfirmationMessage;
        }

        [FindsBy(How = How.XPath, Using = "//input[@value='Continue']")]
        private IWebElement continueBtn;
        public void getContinueBtn()
        {
            continueBtn.Click();
        }

    }
}
