namespace SeleniumDemoProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("Setup");
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("Test 1");
        }

        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("Test 2");
        }

        [TearDown]
        public void TearDown() {
            TestContext.Progress.WriteLine("Tear Down");
        }
    }
}