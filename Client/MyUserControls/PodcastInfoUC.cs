using HonorsClient.Models;
using HonorsClient.MyUserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HonorsClient.MenueUserControls
{
    public partial class PodcastInfoUC : UserControl
    {
        private Podcast _podcast;

        public PodcastInfoUC(Podcast p)
        {
            _podcast = p;
            InitializeComponent();
            TitleLbl.Text = Util.EscapeLabelSpecialCharacters(p.Name);
            AuthorLbl.Text = p.Author;
            DescriptionLbl.Text = p.Description;

            populateEpisodes();
        }

        public PodcastInfoUC(Podcast p, int libraryFlag)
        {
            _podcast = p;
            InitializeComponent();
            TitleLbl.Text = Util.EscapeLabelSpecialCharacters(p.Name);
            AuthorLbl.Text = p.Author;
            DescriptionLbl.Text = p.Description;

            DownloadBtn.Hide();
            populateEpisodesLibrary();
        }

        private async void populateEpisodes()
        {
            foreach (var episode in _podcast.Episodes)
            {
                await AddEpisode(episode);
            }
        }
        private void populateEpisodesLibrary()
        {
            foreach (var episode in _podcast.Episodes)
            {
                AddEpisodeLibrary(episode);
            }
        }

        private async Task AddEpisode(Episode e)
        {
            EpisodeUC episodeUC = new EpisodeUC(e);

            int padding = 10;

            int top = episodePanel.Controls.Count * (episodeUC.Height + padding);
            episodeUC.Location = new Point(0, top);

            episodePanel.Controls.Add(episodeUC);
        }

        private async Task AddEpisodeLibrary(Episode e)
        {
            EpisodeUC episodeUC = new EpisodeUC(e, 1);

            int padding = 10;

            int top = episodePanel.Controls.Count * (episodeUC.Height + padding);
            episodeUC.Location = new Point(0, top);

            episodePanel.Controls.Add(episodeUC);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DownloadBtn_Click(object sender, EventArgs e)
        {
            PodcastLibrary.addPodcastToLibrary(_podcast);
        }
    }
}
