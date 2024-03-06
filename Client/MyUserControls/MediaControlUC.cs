using HonorsClient.Models;
using MediaPlayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HonorsClient.MenueUserControls
{
    public partial class MediaControlUC : UserControl
    {
        private Episode _episode;
        private MediaController _mediaController;
        public MediaControlUC()
        {
            InitializeComponent();
            MediaController.Instance.MediaChanged += OnMediaPlayerMediaChanged;

            frwdBtn.Hide();
            bckBtn.Hide();
        }

        private void OnMediaPlayerMediaChanged(object sender, Episode e)
        {
            _episode = e;
            episodeNameLbl.Text = "Playing " + e.Title;
            setThumbnail(e);

            timer1.Enabled = true;



            _mediaController = MediaController.Instance;
        }

        private void setThumbnail(Episode e)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    var imageBytes = webClient.DownloadData(e.ImageURL);
                    using (var stream = new MemoryStream(imageBytes))
                    {
                        // Create an Image object from the downloaded image
                        var image = Image.FromStream(stream);

                        // Set the PictureBox control's Image property to the downloaded image
                        PodcastThumbnail.SizeMode = PictureBoxSizeMode.StretchImage;
                        PodcastThumbnail.Image = image;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error retrieving podcast thumbnail: {ex.Message}");
            }

        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            var mediaPlayer = MediaController.Instance;

            if (mediaPlayer.playing)
            {
                mediaPlayer.Pause();
                timer1.Enabled = false;

                frwdBtn.Show();
                bckBtn.Show();

            }
            else
            {
                mediaPlayer.Play();
                timer1.Enabled = true;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateEpisodeProgress();
        }



        private void updateEpisodeTimeLabel()
        {
            var mediaPlayer = MediaController.Instance;

            if (mediaPlayer.playing)
            {

                int episodeDuration = mediaPlayer.getDuration();
                int episodeProgress = mediaPlayer.currentPosition();

                episodeTimerLbl.Text = $"{Util.FormatTime(episodeProgress, false)}/{Util.FormatTime(episodeDuration, false)}";

            }

        }

        private void updateEpisodeProgress()
        {
            if (_episode != null)
            {
                PodcastLibrary.updateEpisodeProgress(_episode.FileName, _mediaController.currentPosition());
                PodcastLibrary.saveLibrary();


                Debug.WriteLine($"Episode Duration: {PodcastLibrary.getEpisodeProgress(_episode.FileName)}");
            }
        }

        private void MediaControlUC_Load(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            updateEpisodeTimeLabel();
            var mediaPlayer = MediaController.Instance;

            if (mediaPlayer.playing)
            {
                
                frwdBtn.Show();
                bckBtn.Show();

            }

        }

        private void bckBtn_Click(object sender, EventArgs e)
        {
            if (_mediaController.IsPlaying()) {
                _mediaController.skip(-5);
            }
        }

        private void frwdBtn_Click(object sender, EventArgs e)
        {
            if (_mediaController.IsPlaying())
            {
                _mediaController.skip(5);
            }
        }
    }
}
