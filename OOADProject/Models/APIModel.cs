using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OOADProject
{
    public class APIModel
    {
        private static string gigUrl = "https://rest.bandsintown.com";
        private static string appId = "297c11ac1d5e9ee79d6360d2123be779";
        static HttpClient client = new HttpClient();

        public APIModel()
        {
        }

        public static List<Gig> getGigs(string bandName)
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(gigUrl + "/artists/" + bandName + "/events?app_id=" + appId));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            //Console.WriteLine(WebResp.StatusCode);
            //Console.WriteLine(WebResp.Server);

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            try
            {
                return JsonConvert.DeserializeObject<List<Gig>>(jsonString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<Gig>();
            }
        }
    }
}
