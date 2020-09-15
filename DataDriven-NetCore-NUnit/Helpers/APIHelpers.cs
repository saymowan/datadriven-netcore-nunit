using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace DataDriven_NetCore_NUnit
{
    public class APIHelpers
    {

        //https://reqres.in/api/users
        //Paste and check the json here - http://jsonviewer.stack.hu
        //Only the "data" List Object is important to us!
        public static dynamic GetUsersInfoAPI()
        {
            var client = new RestClient("https://reqres.in");
            var request = new RestRequest("api/users", Method.GET); 

            request.AddHeader("content-type", "application/json");
            IRestResponse<dynamic> response = client.Execute<dynamic>(request);

            return JsonConvert.DeserializeObject<dynamic>(response.Data["data"].ToString());          
        }

    }//end class
}//end namespace