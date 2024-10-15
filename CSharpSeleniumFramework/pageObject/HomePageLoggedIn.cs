using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumFramework.pageObject
{
    class HomePageLoggedIn
    {
        private IWebDriver driver;
        public HomePageLoggedIn(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='newsletter-email']")]
        private IWebElement newsletterBox;
        public IWebElement getNewsLetterBox()
        {
            return newsletterBox;
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='newsletter-subscribe-button']")]
        private IWebElement subscribeBtn;
        public void getSubscribeBtn()
        {
            subscribeBtn.Click();
        }

        [FindsBy(How = How.XPath, Using = "//*[text()='Thank you for signing up! A verification email has been sent. We appreciate your interest.']")]
        private IWebElement subscribeConfirmationMsg;
        public IWebElement getSubscribeConfirmationMsg()
        {
            return subscribeConfirmationMsg;
        }










    }
}
