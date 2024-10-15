using CSharpSeleniumFramework.pageObject;
using CSharpSeleniumFramework.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace CSharpSeleniumFramework.tests
{

    class TestSearchFunction : BaseClass
    {
        SearchFunction searchFunction;
        [SetUp]
        public void setUp()
        {
            searchFunction = new SearchFunction(driver);
        }

    [Test, TestCaseSource(typeof(SearchFieldDataReader), nameof(SearchFieldDataReader.GetTestData))]
    public void testSearchFunctionality(string searchText)
        {
            searchFunction.getMainSearchBox().SendKeys(searchText);
            searchFunction.getMainSearchBtn();

        }

        //IEnumerable : This is an interface that provides a method to retrieve an enumerator for a collection
        //public static IEnumerable<TestCaseData> AddTestDataConfig()
        //{
        //    //Yield used to utilize multiple returns and it waits until all returns are completed
        //    yield return new TestCaseData("Book");
        //    yield return new TestCaseData("Phone");
        //    yield return new TestCaseData("Sneaker");
        //    yield return new TestCaseData("Bracelet");
        //}

        


    }
}
