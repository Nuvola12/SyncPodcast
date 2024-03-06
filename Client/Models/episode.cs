using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HonorsClient.Models
{
    
    public class Episode
    {
        
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string EpisodeURL { get; set; }
        public string ImageURL { get; set; }
        public string PubDate { get; set; }
        public string FileName { get; set; }

        public int duartionProgres { get; set; }



        public Episode(string title, string link, string description, string duration, string episodeURL, string pubDate, string imageURL)
        {
            Title = title;
            Link = link;
            Description = Regex.Replace(description, "<.*?>", string.Empty); ;
            Duration = duration;
            EpisodeURL = episodeURL;
            PubDate = pubDate;
            FileName = Path.GetFileName(episodeURL);
            ImageURL = imageURL;
            duartionProgres = 0;
        }
    }
}
