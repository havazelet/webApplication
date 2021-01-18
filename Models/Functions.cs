using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication1.Models
{
    public class Functions
    {
        public static bool IsIceCream;
        public static bool Isrunning;
        public static float protein = 0;
        public static float lipid = 0;
        public static float energy = 0;
        public static string realImage;
     


        public static string spaces(string content)
        {
            if (content == null)
            {
                return "";
            }
            string c = content;
            if (c.Length > 30)
            {
                for (int i = 30; i < c.Length; i += 30)
                {
                    //while (c[i] != ' ')
                    //    i--;
                    c = c.Substring(0, i) + "\n" + c.Substring(i++);
                }
            }
            return c;
        }

        public async Task RunAsync(string url)   //imagga
        {
            string apiKey = "acc_8678c534c4ea86f";
            string apiSecret = "7a09f29a880eaee8a3084cab974e157e";
            string imageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQkve0uNqWQ2aZwTxWH75Vzd9YBZL5O23vNPXD9gfRgk9OOM6rY";
            string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.imagga.com/v2/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", String.Format("Basic {0}", basicAuthValue));

                HttpResponseMessage response = await client.GetAsync(String.Format("tags?image_url={0}", url));

                HttpContent content = response.Content;
                string result = await content.ReadAsStringAsync();
                JObject jobject = JObject.Parse(result);
                //Console.WriteLine(result);
                //Console.ReadKey();
                //Console.WriteLine(jobject["result"]["tags"][0].ToString());
                //Console.ReadKey();
                bool ok = false;
                for (int i = 0; i < 5; i++)
                {
                    var k = jobject["result"]["tags"][i]["tag"]["en"].ToString();
                    if (k == "ice" || k == "cream" || k == "ice cream" || k == "creamy" || k == "frozen")
                    {
                        IsIceCream = true;
                        break;
                    }
                    else
                    {
                        IsIceCream = false;
                    }
                }
                realImage = jobject["result"]["tags"][0]["tag"]["en"].ToString();
            }
        }

        public async Task Nutrients(string ProductCode)  //haklahot
        {
            string url = "https://api.nal.usda.gov/ndb/V2/";
            //string ProductId = "11209";
            //ProductCode = "11209";
           
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(@"application/json"));
              //  rzkoV1AbLkno2Ezzuzn6SutXVTiH8HAlMDilyUc0
                //5mEUAFea00DNtBHMv4jI6kFGRqMGORhK1Ohm3ZFh"
                HttpResponseMessage response = await client.GetAsync(string.Format("reports?ndbno={0}&type=f&format=json&api_key=rzkoV1AbLkno2Ezzuzn6SutXVTiH8HAlMDilyUc0", ProductCode));
                HttpContent content = response.Content;
                string result = await content.ReadAsStringAsync();
                JObject jobject = JObject.Parse(result);
                Console.WriteLine(result);

                var nutrients = jobject["foods"][0]["food"]["nutrients"];
                for (int i = 0; i < nutrients.Count(); i++)
                {
                   // var k = jobject["foods"]["food"][i]["tag"]["en"].ToString();
                    if (nutrients[i]["name"].ToString() == "Protein")
                    {
                        protein = (float)nutrients[i]["value"];
                    }
                    if (nutrients[i]["name"].ToString() == "Total lipid (fat)")
                    {
                        lipid = (float)nutrients[i]["value"];
                    }
                    if (nutrients[i]["name"].ToString() == "Energy")
                    {
                        energy = (float)nutrients[i]["value"];
                    }

                }
            }
        }
    }
}