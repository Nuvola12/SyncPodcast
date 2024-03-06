using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WMPLib;

namespace HonorsClient.Models
{
    internal class MediaController
    {
        public event EventHandler<Episode> MediaChanged;

        private static readonly MediaController instance = new MediaController();

        public static MediaController Instance { get { return instance; } }

        private Episode currentEpisode;


        private WindowsMediaPlayer wmp;

        public bool IsPlaying()
        {
            return (wmp.playState == WMPPlayState.wmppsPlaying);
        }

        public void skip(int time) {
            wmp.controls.currentPosition += time;
        }

        private MediaController()
        {
            wmp = new WindowsMediaPlayer();
            wmp.PlayStateChange += OnPlayStateChange;
            setVolume(50);
        }

        public int getDuration() {
            return (int)wmp.currentMedia.duration;
        }

        public int currentPosition() {
            return (int)wmp.controls.currentPosition;
        }

        public void setCurrentPosition(int position) {
            wmp.controls.currentPosition = position;
        }

        private void OnPlayStateChange(int newState)
        {
            if (newState == (int)WMPPlayState.wmppsPlaying)
            {
                

                if ($"local/media/{currentEpisode.FileName}" != wmp.URL)
                {
                    currentEpisode.FileName = wmp.URL;
                    if (MediaChanged != null)
                    {
                        MediaChanged(this, currentEpisode);
                    }
                }
            }
        }


        public void Play()
        {
            wmp.controls.play();
            playing = true;
        }
        public void Pause()
        {
            wmp.controls.pause();
            playing = false;
        }

        public void Stop()
        {
            wmp.controls.stop();
        }

        public void setVolume(int volume) { 
            if (volume > 0 && volume < 100) {
                wmp.settings.volume = volume;
            }
        }

        public bool playing {  get; set; }

        public void setAudioFile(Episode e) {
            currentEpisode = e;
            string episodeLocation = $"local/media/{e.FileName}";


            if (episodeLocation.StartsWith("local/media/") && episodeLocation.Contains("local\\media\\"))
            {
                wmp.URL = e.FileName;
                Debug.WriteLine($"Added file {e.FileName} to queue"); 
            }
            else {
                Debug.WriteLine($"Added file {episodeLocation} to queue"); 
                wmp.URL = episodeLocation;
            }



            Debug.WriteLine($"Current progress on episodes being queued is {e.duartionProgres}"); 
            wmp.controls.currentPosition = e.duartionProgres;
        }
    }
}
