using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumFramework.pageObject
{
    internal class SearchFunction
    {

        private IWebDriver driver;
        public SearchFunction(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='small-searchterms']")]
        private IWebElement mainSearchBox;
        public IWebElement getMainSearchBox()
        {
            return mainSearchBox;
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='small-searchterms']")]
        private IWebElement mainSearchBtn;
        public void getMainSearchBtn()
        {
            mainSearchBtn.Click();
        }

    }
}
