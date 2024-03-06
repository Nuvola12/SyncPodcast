using HonorsClient.DataAccess;
using HonorsClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HonorsClient.MyUserControls
{
    public partial class EpisodeUC : UserControl
    {
        private Episode _episode;

        public EpisodeUC(Episode e)
        {
            _episode = e;
            InitializeComponent();
            titleLbl.Text = Util.EscapeLabelSpecialCharacters(e.Title);
            DescriptionLbl.Text = e.Description;
            button1.Hide();
            QueueBtn.Hide();
        }

        public EpisodeUC(Episode e, int libraryFlag)
        {
            _episode = e;
            InitializeComponent();

            titleLbl.Text = Util.EscapeLabelSpecialCharacters(e.Title);
            
            
           // try { TimeInfoLbl.Text = $"{Util.ExtractDate(e.PubDate)} / {Util.FormatTime(int.Parse(e.Duration), true)}"; } catch { }
            
            
            DescriptionLbl.Text = e.Description;
            QueueBtn.Show();


        }



        private void button1_Click(object sender, EventArgs e)
        {


            EpisodesDownloaded.addEpisode(_episode);
            EpisodesDownloaded.printEpisodes();

            DownloadEpisode.Download(_episode);



        }

        private void QueueBtn_Click(object sender, EventArgs e)
        {
            var mi = MediaController.Instance;


            Thread.Sleep(1000); //? makes it work for unknown reason(probably because the episode needs to somewhat buffer before attemping to asign a file location)
            mi.setAudioFile(_episode);

            mi.Play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (PodcastLibrary.isDownloaded(_episode))
            {
                QueueBtn.Enabled = true;
                button1.Enabled = false;
                
                QueueBtn.BackColor = Color.White; 
                button1.BackColor = Color.DarkGray; 
            }
            else
            {
                QueueBtn.Enabled = false;
                button1.Enabled = true;

                QueueBtn.BackColor = Color.DarkGray;
                button1.BackColor = Color.White;
            }
        }
    }
}
