using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HonorsClient.Models
{
    public class Podcast
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string ImageURL { get; set; }

        public List<Episode> Episodes { get; set; }

        public Podcast(string name, string description, string author, string imageURL)
        {
            Name = name;
            Description = Regex.Replace(description, "<.*?>", string.Empty); ;
            Author = author;
            ImageURL = imageURL;
            Episodes = new List<Episode>();
        }

        public static async Task<Podcast> BuildPodcastFromRSS(string rssFeedUrl)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(rssFeedUrl);
                    response.EnsureSuccessStatusCode();

                    var xml = await response.Content.ReadAsStringAsync();
                    var doc = XDocument.Parse(xml);

                    var itunesNS = XNamespace.Get("http://www.itunes.com/dtds/podcast-1.0.dtd");

                    var channel = doc.Descendants("channel").FirstOrDefault();
                    var podcastName = channel.Element("title").Value;
                    var podcastDescription = channel.Element("description").Value;
                    var podcastAuthor = channel.Element(itunesNS + "author").Value;
                    var podcastImageURL = channel.Element(itunesNS + "image")?.Attribute("href")?.Value;

                    var podcast = new Podcast(podcastName, podcastDescription, podcastAuthor, podcastImageURL);

                    var items = doc.Descendants("item");
                    foreach (var item in items)
                    {
                        var episodeTitle = item.Element("title").Value;
                        var episodeLink = item.Element("link")?.Value;
                        var episodeDescription = item.Element("description")?.Value;
                        var pubDate = item.Element("pubDate")?.Value;
                        var episodeDuration = item.Element(itunesNS + "duration")?.Value;
                        var enclosure = item.Element("enclosure");
                        var episodeURL = enclosure.Attribute("url").Value;

                        var episode = new Episode(episodeTitle, episodeLink, episodeDescription, episodeDuration, episodeURL, pubDate,podcastImageURL);
                        podcast.Episodes.Add(episode);
                    }

                    return podcast;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error retrieving podcast: {ex.Message}");
                return null;
            }
        }

        
    }

}
