using CSharpSeleniumFramework.pageObject;
using CSharpSeleniumFramework.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumFramework.tests
{
    class TestHomePageLoggedIn : BaseClass
    {
        HomePageLoggedIn homePageLoggedIn;
        LoginPage loginPage;
        [SetUp]
        public void SetUpTest()
        {
            // Initialize LoginPage with the driver from BaseClass
            loginPage = new LoginPage(driver, Username, Password);
            homePageLoggedIn = new HomePageLoggedIn(driver);
           

        }

        [Test]
        public void test1()
        {
            loginPage.validLogin();
            homePageLoggedIn.getNewsLetterBox().SendKeys(GenerateRandomEmail(8));
            homePageLoggedIn.getSubscribeBtn();
            WaitForElement(homePageLoggedIn.getSubscribeConfirmationMsg(), e=> e.Displayed);
            Assert.That(homePageLoggedIn.getSubscribeConfirmationMsg().Text, 
                Does.Contain("Thank you for signing up"), "Sign Up confirmation mismatch");



        }










    }
}
