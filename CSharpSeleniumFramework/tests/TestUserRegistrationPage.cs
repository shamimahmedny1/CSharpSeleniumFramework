using CSharpSeleniumFramework.pageObject;
using CSharpSeleniumFramework.utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumFramework.tests
{
    [TestFixture]
    class testUserRegistrationPage : BaseClass
    {
        private UserRegistrationPage userRegistrationPage;
        private GenerateUserData userData;

        [SetUp]
        public void SetUpTest()
        {
            // Initialize LoginPage with the driver from BaseClass
            userRegistrationPage = new UserRegistrationPage(driver);
            userData = new GenerateUserData();
        }

        [Test]
        public void testRegistrationPage()
        {
            userRegistrationPage.getMainRegistrationBtn();
            // Generate random user data
            string firstName = userData.GenerateRandomFirstName();
            string lastName = userData.GenerateRandomLastName();
            string email = userData.GenerateRandomEmail();
            string password = userData.GenerateRandomPassword();
            string gender = userData.GenerateRandomGender();
            userData.GenerateRandomUserDetails();
            // Select gender
            if (gender == "Male")
            {
                userRegistrationPage.getMaleRadioBtn();
            }
            else
            {
                userRegistrationPage.getFemaleRadioBtn();
            }
            // Fill in the registration form
            userRegistrationPage.getFirstName().SendKeys(firstName);
            userRegistrationPage.getLastName().SendKeys(lastName);
            userRegistrationPage.getEmail().SendKeys(email);
            userRegistrationPage.getPassword().SendKeys(password);
            userRegistrationPage.getConfirmPassword().SendKeys(password);

            // Click the Register button
            userRegistrationPage.getRegisterBtn();
            Console.WriteLine(userRegistrationPage.getRegistrationConfirmationMessage().Text);
            Assert.That(userRegistrationPage.getRegistrationConfirmationMessage().Text,
                Is.EqualTo("Your registration completed"), "Registration Confirmation Message Does not match");

            userRegistrationPage.getContinueBtn();

        }
    }
}
