using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HonorsClient.Models
{
    public class FeedResult
    {
        public string FeedUrl { get; set; }
        public string CollectionName { get; set; }
        public string artistName { get; set; }
    }

    public static class FeedResultParser
    {
        public static List<FeedResult> Parse(string resultString)
        {
            var resultObject = JsonConvert.DeserializeObject<dynamic>(resultString);

            List<FeedResult> results = new List<FeedResult>();
            foreach (var result in resultObject.Results)
            {
                results.Add(new FeedResult
                {
                    FeedUrl = result.FeedUrl,
                    CollectionName = result.CollectionName,
                    artistName = result.ArtistName
                });
            }

            return results;
        }
    }
}
