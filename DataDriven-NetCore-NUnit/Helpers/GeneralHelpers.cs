using System;
using NUnit.Framework;

namespace DataDriven_NetCore_NUnit
{
    public class GeneralHelpers
    {

        public static string GetProjectPath()
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;

            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));

            return new Uri(actualPath).LocalPath;
        }


    }//end class
}//end namespace