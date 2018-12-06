using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OOADProject
{
    public class APIModel
    {

        private static string gigUrl = "https://rest.bandsintown.com";
        private static string appId = "297c11ac1d5e9ee79d6360d2123be779";
        //private string bandName;

        static HttpClient client = new HttpClient();

        public APIModel(/*string bandName*/)
        {
           // this.bandName = bandName;
        }

        /*
        static async Task<Gig> GetProductAsync(string path)
        {
            Gig gig = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                gig = await response.Content.ReadAsAsync<Gig>();
            }
            return gig;
        }

    

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri(gigUrl + "/artists/" + "BrowsingCollection" + "/events?app_id=" + appId);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        } */

        /*async*/ public static List<Gig> getGigs(string bandName) //How to recieve list with string, doctionary and string, string???
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
