using DataDriven_NetCore_NUnit.Helpers;
using NUnit.Framework;

namespace DataDriven_NetCore_NUnit
{
    public class DataDrivenDataBaseTests
    {

        [TestCaseSource(typeof(DataDrivenHelpers),"ReturnDataUsingDataBase")]
        public void UsingDataBaseSource(string name, string email)
        {
            //some acts on the website using the "name" parameter
            //some acts on the website using the "email" parameter
            string nome = string.Empty;
            Assert.Pass();
        }


    }
}