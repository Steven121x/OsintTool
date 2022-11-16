
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IP_Multi_Tool.Class
{
    internal class NumVerify
    {
         public static void GetinfoNumber(string number)
         {
            var client = new RestClient($"https://api.apilayer.com/number_verification/validate?number={number}");
            client.Timeout = -1;

            var request = new RestRequest(Method.GET);
            request.AddHeader("apikey", "qe2hX5I8Zx2XNvECyumHOqcs1QCT5P5v");

            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            string source = response.ToString();

           var carrier1  = Parse(source, "\"carrier\":", "\"").FirstOrDefault();
            MessageBox.Show(carrier1.ToString());

         }

        private static string Parse(string source, string left, string right)
        {
            return source.Split(new string[]
            {
                left
            }, StringSplitOptions.None)[1].Split(new string[]
            {
                right
            }, StringSplitOptions.None)[0];
        }

        //Variables

        public static string carrier;
        public static string country_code;
        public static string country_name;
        public static string Country_prefix;
        public static string international_format;
        public static string line_Type;
        public static string local_format;
        public static string location;
        public static string number;
        public static string valid;
    }
}
