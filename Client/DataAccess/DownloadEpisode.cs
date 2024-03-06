using HonorsClient.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HonorsClient.DataAccess
{
    internal class DownloadEpisode
    {
        private static void makeFolders()
        {
            string path = Path.Combine(Application.StartupPath, "local/media");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static async void Download(Episode e) {
            if (e != null)
            {

                string fileLocation = $"local/media/{e.FileName}";
                makeFolders();
                await DownloadMP3Async(e.EpisodeURL, fileLocation);

            }
        }


        private static async Task DownloadMP3Async(string url, string filePath)
        {
            using (WebClient client = new WebClient())
            {
                await client.DownloadFileTaskAsync(url, filePath);
            }

            Debug.WriteLine("(+) Finished Downloading Episode");
        }
    }
}
