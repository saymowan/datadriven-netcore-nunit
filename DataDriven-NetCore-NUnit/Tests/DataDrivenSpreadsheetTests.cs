using DataDriven_NetCore_NUnit.Helpers;
using NUnit.Framework;

namespace DataDriven_NetCore_NUnit
{
    public class DataDrivenSpreadsheetTests
    {
      
        [TestCaseSource(typeof(DataDrivenHelpers),"ReturnNameTelephone_CSV")]
        public void UsingCSVSource(string name, string telephoneNumber)
        {
            //some acts on the website using the "name" parameter
            //some acts on the website using the "telephoneNumber" parameter
            Assert.Pass();
        }


        [TestCaseSource(typeof(DataDrivenHelpers),"ReturnNameTelephone_XLSX")]
        public void UsingXLSXSource(string name, string telephoneNumber)
        {
            //some acts on the website using the "name" parameter
            //some acts on the website using the "telephoneNumber" parameter
            Assert.Pass();
        }

    }
}