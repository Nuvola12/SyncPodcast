using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace UnitTests
{
    public class SearchResponse
    {
        public SearchResult[] Results { get; set; }
    }

    public class SearchResult
    {
        public string FeedUrl { get; set; }
        public string CollectionName { get; set; }

        public string[] genres { get; set; }

        public string artistName { get; set; }

    }

    public class ItunesLookup
    {
        public static string lookupPodcast(string podcastName)
        {
            // Encode the podcast name to handle spaces and special characters
            string encodedName = HttpUtility.UrlEncode(podcastName);

            // Search for the podcast on iTunes and get the first result
            string url = $"https://itunes.apple.com/search?term={encodedName}&entity=podcast";
            string responseString = new HttpClient().GetStringAsync(url).Result;
            // Deserialize the JSON response into strongly-typed objects
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var response = JsonSerializer.Deserialize<SearchResponse>(responseString, options);

            // Get the URL of the first search result
            if (response.Results.Length > 0)
            {
                return JsonSerializer.Serialize(response);
            }
            else
            {
                Console.WriteLine($"No results found for '{podcastName}'");
                return "";
            }
        }
    }
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
    internal class Methods
    {
    }
}
