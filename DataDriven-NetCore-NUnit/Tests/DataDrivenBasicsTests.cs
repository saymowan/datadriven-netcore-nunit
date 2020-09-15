using DataDriven_NetCore_NUnit.Helpers;
using NUnit.Framework;

namespace DataDriven_NetCore_NUnit
{
    public class DataDrivenBasicsTests
    {

        [TestCase("Irene J. Hunt","3022694414")]
        [TestCase("Michael D. Young","8056736694")]
        [TestCase("Andrew G. Jordan","3018291606")]
        [TestCase("Bryan J. Gabriel","2547151195")]
        [TestCase("Deborah J. Norman","3257436174")]
        [TestCase("Paul K. Boyd","6316959735")]
        public void UsingTestCase1(string name, string telephoneNumber)
        {
            //some acts on the website using the "name" parameter
            //some acts on the website using the "telephoneNumber" parameter
            Assert.Pass();
        }


        [TestCase(5, 6, 11)]
        [TestCase(12, 1, 13)]
        [TestCase(14, 5, 19)]
        [TestCase(12, 12, 24)]
        public void UsingTestCase2(int param1, int param2, int expectedResult)
        {
            int sumNumbers = param1 + param2;
            Assert.AreEqual(expectedResult, sumNumbers);
        }


        [Test]
        public void UsingCombinatorial(
            [Values("Irene J. Hunt", "Michael D. Young", "Andrew G. Jordan")] string names, 
            [Values("3022694414", "8056736694","3018291606")] string telephoneNumber)
        {
            //some acts on the website using the "name" parameter
            //some acts on the website using the "telephoneNumber" parameter
            Assert.Pass();
        }


        static string[] telephoneNumberList = {"3022694414", "8056736694","3018291606"};

        [TestCaseSource("telephoneNumberList")]
        public void UsingTestCaseSourceListString(string telephoneNumber)
        {
            //some acts on the website using the "telephoneNumber" parameter
            Assert.Pass();
        }


        static object[] PersonData =
        {
            new object[] { "Irene J. Hunt", "1156736694" },  //TestCase1
            new object[] { "Michael D. Young", "8056736694"} //TestCase2
        };


        [TestCaseSource("PersonData")]
        public void UsingTestCaseSourceMultipleObj(string name, string telephoneNumber)
        {
            //some acts on the website using the "name" parameter
            //some acts on the website using the "telephoneNumber" parameter
            Assert.Pass();
        }

    }
}