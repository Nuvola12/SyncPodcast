using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Forms;
using HonorsClient.DataAccess;
using System.Net;

namespace HonorsClient.Models
{
    internal class PodcastLibrary
    {
        private static List<Podcast> podcastLibrary = new List<Podcast>();

        public static void addPodcastToLibrary(Podcast p) {

            Debug.WriteLine($"(+) Added Library {p.Name} to library");
            if (!podcastLibrary.Contains(p)) {
                podcastLibrary.Add(p);
                saveLibrary();
            }
        }

        public static void updateEpisodeProgress(string episodeFileName, int progress) {
            foreach (Podcast podcast in podcastLibrary)
            {
                foreach (Episode episode in podcast.Episodes)
                {
                    if (episode.FileName == episodeFileName)
                    {
                        episode.duartionProgres = progress;
                        Debug.WriteLine("");
                        return; 
                    }
                }
            }
        }

        public static int getEpisodeProgress(string episodeFileName) {

            foreach (Podcast podcast in podcastLibrary)
            {
                foreach (Episode episode in podcast.Episodes)
                {
                    if (episode.FileName == episodeFileName)
                    {
                        return episode.duartionProgres;
                    }
                }
            }

            return 0;
        }

        public static void loadLibrary() 
        {
            
            string jsonString;
            if ((jsonString = Database.SendGetRequest("https://localhost:44390/api/data", User.APIKey) )!= null)
            {
                podcastLibrary = System.Text.Json.JsonSerializer.Deserialize<List<Podcast>>(jsonString);
            }
            else {
                /*
                if (File.Exists("myLibrary.json"))
                {
                    jsonString = File.ReadAllText("myLibrary.json");

                    podcastLibrary = System.Text.Json.JsonSerializer.Deserialize<List<Podcast>>(jsonString);
                }
                */
            }

        }

        public static bool isDownloaded(Episode e)
        {
            string episodeLocation = $"local/media/{e.FileName}";

            if (episodeLocation.StartsWith("local/media/") && episodeLocation.Contains("local\\media\\"))
            {
                return File.Exists(e.FileName);
            }
            else
            {
                return File.Exists($"local\\media\\{e.FileName}");
            }


        }

        public static void saveLibrary()
        {
            var library = PodcastLibrary.getPodcastLibrary();

            string jsonString = System.Text.Json.JsonSerializer.Serialize(library,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            if (File.Exists("myLibrary.json"))
            {
                File.Delete("myLibrary.json");
            }

            using (StreamWriter sw = new StreamWriter("myLibrary.json"))
            {
                sw.Write(jsonString);
            }

            Database.SendPostRequestJSON("https://localhost:44390/api/data", User.APIKey, "myLibrary.json");
        }

        public static List<Podcast> getPodcastLibrary() {
            return podcastLibrary;
        }
    }

    internal class EpisodesDownloaded
    {
        
        private static List<Episode> episodes = new List<Episode>();

        public static void addEpisode(Episode ep)
        {
            Debug.WriteLine($"Episode Added to downloaded list{ep.Title}");
            if(!episodes.Contains(ep))
            {
                episodes.Add(ep);
            }
        }

        

        public static List <Episode> getEpisodes() {  return episodes; }
        
        public static void removeEpisode(Episode ep) { episodes.Remove(ep); }

        public static void printEpisodes() { foreach (var x in episodes) Debug.WriteLine($"Podcast episode {x.Title}"); }

        
    }
}
