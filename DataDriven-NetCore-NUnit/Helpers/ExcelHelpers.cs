using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using NUnit.Framework;

public class ExcelHelpers
    {

        //Install x64: Microsoft Access Database Engine 2010 Redistributable - https://www.microsoft.com/en-us/download/details.aspx?id=13255
        //Throubleshoot: https://social.msdn.microsoft.com/Forums/pt-BR/1d5c04c7-157f-4955-a14b-41d912d50a64/how-to-fix-error-quotthe-microsoftaceoledb120-provider-is-not-registered-on-the-local?forum=vstsdb
        //Variable "cmdText" reffer your spreadsheet tab that which have testdata, in this case "Tab1" in the NameTelephone.xlsx file
        public List<TestCaseData> ReadExcelData(string excelFile, string cmdText = "SELECT * FROM [Tab1$]")
        {
            string connectionStr = ConnectionStringExcel(excelFile);
            var ret = new List<TestCaseData>();

            using (var connection = new OleDbConnection(connectionStr))
            {
                connection.Open();
                var command = new OleDbCommand(cmdText, connection);
                var reader = command.ExecuteReader();
                if (reader == null)
                    throw new Exception(string.Format("No data return from file, file name:{0}", excelFile));

                while (reader.Read())
                {
                    if  (!string.IsNullOrEmpty(reader.GetValue(0).ToString()))
                    {
                    var row = new List<string>();
                    var feildCnt = reader.FieldCount;

                    for (var i = 0; i < feildCnt; i++)

                        row.Add(reader.GetValue(i).ToString());

                    ret.Add(new TestCaseData(row.ToArray()));

                    }
                }
                return ret;
            }
        }

        public static String ConnectionStringExcel(string excelFile){

            if (!File.Exists(excelFile))
            throw new Exception(string.Format("File name: {0}", excelFile), new FileNotFoundException());
            string connectionStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES\";", excelFile);
            
            return connectionStr;
        }


       
    }