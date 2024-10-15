using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumFramework.utilities
{
    class SearchFieldDataReader
    {
        // Method to read JSON and return test data as IEnumerable<TestCaseData>
        public static IEnumerable<TestCaseData> GetTestData()
        {
            // Get the project root directory
            string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            // Build the path to the JSON file
            string filePath = Path.Combine(projectRoot, "testdata", "SearchFieldData.json");


            // Read the content of the JSON file
            var jsonData = File.ReadAllText(filePath);

            // Deserialize the JSON data into a list of SearchData objects
            var searchDataList = JsonConvert.DeserializeObject<List<SearchData>>(jsonData);

            // Convert the data into NUnit TestCaseData format
            foreach (var data in searchDataList)
            {
                yield return new TestCaseData(data.SearchText);
            }
        }
    }

    // Class to map the JSON data structure
    public class SearchData
    {
        public string SearchText { get; set; }
    }
}
