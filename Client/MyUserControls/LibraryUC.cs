using HonorsClient.MenueUserControls;
using HonorsClient.Models;
using HonorsClient.MyUserControls;
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

namespace HonorsClient.UserControls
{
    public partial class LibraryUC : UserControl
    {

        private static LibraryUC _instance;
        private static Panel _targetPanel;


        public static LibraryUC Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LibraryUC(_targetPanel);

                }
                return _instance;
            }
        }

        private async void fillLibrary()
        {
            foreach (var podcast in PodcastLibrary.getPodcastLibrary())
            {
                await AddNewUserControl(podcast);
            }
        }

        private async Task AddNewUserControl(Podcast p)
        {
            // Create a new instance of your custom user control
            SearchResponseUC newUserControl = new SearchResponseUC(p, _targetPanel, 1);

            // Set the position of the new user control based on the number of controls already added to the panel
            int top = podcastPanel.Controls.Count * newUserControl.Height;
            newUserControl.Location = new Point(0, top);

            // Add the new user control to the panel
            podcastPanel.Controls.Add(newUserControl);
        }

        public static void InitializeWithPanel(Panel targetPanel)
        {
            if (_targetPanel == null)
                _targetPanel = targetPanel;
        }

        public void reloadLibrary()
        {
            //call when already in creation and brought forward
            //clear panel and refill it
            //couldd check if library has changed first

            Debug.WriteLine("(+) Reloaded Library");

            podcastPanel.Controls.Clear();

            PodcastLibrary.loadLibrary();

            fillLibrary();
        }
        public LibraryUC(Panel targetPanel)
        {
            InitializeComponent();

            var lib = PodcastLibrary.getPodcastLibrary();



            foreach (var item in lib)
            {
                Debug.WriteLine($"Podcast {item.Name}");
            }

            //reloadLibrary();
        }
    }
}
