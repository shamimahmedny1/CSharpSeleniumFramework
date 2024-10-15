using CSharpSeleniumFramework.utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpSeleniumFramework.pageObject;


namespace CSharpSeleniumFramework.tests
{
    class TestLoginPage : BaseClass
    {
        private LoginPage loginPage;

        [SetUp]
        public void SetUpTest()
        {
            // Initialize LoginPage with the driver from BaseClass
            loginPage = new LoginPage(driver, Username, Password);
        }

        [Test]
        public void test1() {
            loginPage.validLogin();
            WaitForElementToBeClickable(loginPage.getLogOutBtn());
            Assert.That(loginPage.getLogOutBtn()
                .Displayed, Is.True, "Logout button is not present or visible.");
            loginPage.getLogOutBtn().Click();


        }
    }
}
