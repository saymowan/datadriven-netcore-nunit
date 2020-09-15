using DataDriven_NetCore_NUnit.Helpers;
using NUnit.Framework;

namespace DataDriven_NetCore_NUnit
{
    public class DataDrivenAPITests
    {
    

        [TestCaseSource(typeof(DataDrivenHelpers),"ReturnDataUsingAPI")]
        public void UsingAPISource(string name, string email)
        {
            //some acts on the website using the "name" parameter
            //some acts on the website using the "email" parameter
            Assert.Pass();
        }

    }
}