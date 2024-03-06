using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HonorsClient.DataAccess
{
    public class Database
    {
        public static string SendGetRequest(string url, string apiKey)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create($"{url}/{apiKey}");
                request.Method = "GET";

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                if (string.IsNullOrWhiteSpace(responseString))
                {
                    return null;
                }
                else
                {
                    return responseString;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static void SendPostRequestJSON(string url, string apiKey, string jsonFilePath)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";

                var jsonData = File.ReadAllText(jsonFilePath);
                var postData = new
                {
                    APIKey = apiKey,
                    LibraryData = jsonData
                };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(postData);
                var data = Encoding.UTF8.GetBytes(json);
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                Console.WriteLine(responseString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
