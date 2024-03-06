using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace HonorsClient.DataAccess
{
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
            var response = JsonSerializer.Deserialize<Models.SearchResponse>(responseString, options);

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
}
