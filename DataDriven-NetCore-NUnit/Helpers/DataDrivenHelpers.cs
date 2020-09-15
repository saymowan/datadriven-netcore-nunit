using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using DataDriven_NetCore_NUnit.Helpers;
using NUnit.Framework;

namespace DataDriven_NetCore_NUnit
{
    public class DataDrivenHelpers
    {


    public static List<TestCaseData> ReturnNameTelephone_CSV
        {
            get
            {
                var testCases = new List<TestCaseData>();
        
                using (var fs = File.OpenRead(GeneralHelpers.GetProjectPath() + @"\DataDriven\Files\NameTelephone.csv"))
                using (var sr = new StreamReader(fs))
                {
                    string headerLine = sr.ReadLine();

                    string line = string.Empty;
                    while (line != null)
                    {
                        line = sr.ReadLine();

                        if (line != null)
                        {
                            string[] split = line.Split(new char[] { ',' },
                                StringSplitOptions.None);
        
                            string param1 = Convert.ToString(split[0]); //name
                            string param2 = Convert.ToString(split[1]); //telephone
        
                            var testCase = new TestCaseData(param1, param2);
                            testCases.Add(testCase);
                        }
                    }
                }
        
                return testCases;
            }
        }//end method


        static object[] PersonData =
        {
            new object[] { "Irene J. Hunt", "1156736694" },  //TestCase1
            new object[] { "Michael D. Young", "8056736694"} //TestCase2
        };



        public static IEnumerable<TestCaseData> ReturnNameTelephone_XLSX
        {
            get
            {
                var testCases = new List<TestCaseData>();
                testCases = new ExcelHelpers().ReadExcelData(GeneralHelpers.GetProjectPath() + @"\DataDriven\Files\NameTelephone.xlsx");
               
                if (testCases != null)
                    foreach (TestCaseData testCaseData in testCases)
                        yield return testCaseData;
                }
        }

    
       public static List<TestCaseData>  ReturnDataUsingAPI()
        {
            var testcase = new List<TestCaseData>();
            var users = APIHelpers.GetUsersInfoAPI();
            Console.WriteLine(users);
            
           foreach (var user in users)
           {
               testcase.Add(new TestCaseData(user.first_name.ToString(), user.email.ToString()));
           }

           return testcase;
        }

        public static List<TestCaseData>  ReturnDataUsingDataBase()
        {
            var testcase = new List<TestCaseData>();
            DataTable users = DataBaseHelpers.RetornaDadosDataTableQuery("SELECT * FROM `user`");
            Console.WriteLine(users);

            foreach(DataRow row in users.Rows)
            { 
                testcase.Add(new TestCaseData(row[1].ToString(), row[2].ToString()));
            }

           return testcase;
        }



    }
}