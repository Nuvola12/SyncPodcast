using HonorsClient.DataAccess;
using HonorsClient.Models;
using HonorsClient.UserControls;
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
    public partial class SearchResponseUC : UserControl
    {
        private Podcast _podcast;

        private Panel _targetPanel;

        bool isLibrary = false;

        private void setThumbnail()
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    var imageBytes = webClient.DownloadData(_podcast.ImageURL);
                    using (var stream = new MemoryStream(imageBytes))
                    {
                        // Create an Image object from the downloaded image
                        var image = Image.FromStream(stream);

                        // Set the PictureBox control's Image property to the downloaded image
                        thumbnailPB.SizeMode = PictureBoxSizeMode.StretchImage;
                        thumbnailPB.Image = image;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error retrieving podcast thumbnail: {ex.Message}");
            }

        }

        public SearchResponseUC(Podcast podcast, Panel panel)
        {
            InitializeComponent();
            thumbnailPB.Height = panel1.Height - 15;
            thumbnailPB.Width = panel1.Height - 15;
            _podcast = podcast;
            AuthorLbl.Text = podcast.Author;
            textLbl.Text = Util.EscapeLabelSpecialCharacters(podcast.Name) ;
            setThumbnail();

            _targetPanel = panel;
        }

        public SearchResponseUC(Podcast podcast, Panel panel, int libraryFlag)
        {
            InitializeComponent();
            thumbnailPB.Height = panel1.Height - 15;
            thumbnailPB.Width = panel1.Height - 15;
            _podcast = podcast;
            AuthorLbl.Text = podcast.Author;
            textLbl.Text = Util.EscapeLabelSpecialCharacters(podcast.Name);

            setThumbnail();

            _targetPanel = panel;
            isLibrary = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PodcastInfoUC podcastInfoUC;
            if (!isLibrary)
            {
                podcastInfoUC = new PodcastInfoUC(_podcast);
            }
            else
            {
                podcastInfoUC = new PodcastInfoUC(_podcast, 1);
            }
            // Bad implementation for checking if is being added to a library

            if (!_targetPanel.Controls.Contains(podcastInfoUC))
            {
                //Bug where you add a podcast and do an new search term clicking on a podcast will crash 

                _targetPanel.Controls.Add(podcastInfoUC);
                podcastInfoUC.Dock = DockStyle.Fill;
                podcastInfoUC.BringToFront();
            }
            else
            {
                podcastInfoUC.BringToFront();
            }


        }
    }
}
