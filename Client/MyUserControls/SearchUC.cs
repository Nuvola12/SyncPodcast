using HonorsClient.DataAccess;
using HonorsClient.MenueUserControls;
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

namespace HonorsClient.UserControls
{
    public partial class SearchUC : UserControl
    {
        private static SearchUC _instance;
        private static Panel _targetPanel;


        public static SearchUC Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SearchUC(_targetPanel);
                return _instance;
            }
        }

        public static void InitializeWithPanel(Panel targetPanel)
        {
            if (_targetPanel == null)
                _targetPanel = targetPanel;
        }

        public SearchUC(Panel targetPanel)
        {
            InitializeComponent();
            SearchTextBox.KeyPress += KeyPressReg;
        }

        private void KeyPressReg(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                Search();
            }
        }

        private async Task AddNewUserControl(Podcast p)
        {
            // Create a new instance of your custom user control
            SearchResponseUC newUserControl = new SearchResponseUC(p, _targetPanel);

            // Set the position of the new user control based on the number of controls already added to the panel
            int top = SearchResponsePanel.Controls.Count * newUserControl.Height;
            newUserControl.Location = new Point(0, top);

            // Add the new user control to the panel
            SearchResponsePanel.Controls.Add(newUserControl);
        }

        private async void Search() {
            SearchResponsePanel.Controls.Clear();
            Debug.WriteLine($"Searching for podcasat {SearchTextBox.Text}");
            string resultString = ItunesLookup.lookupPodcast(SearchTextBox.Text);

            List<FeedResult> results = FeedResultParser.Parse(resultString);

            int numSearches = Math.Min(results.Count, 10);
            //Gets the top 20 results if there are more then 10 results returned as it can use up too much memory {https://www.tutorialspoint.com/math-min-method-in-chash#:~:text=Min()%20Method%20in%20C%23&text=The%20Math.,%2C%20Int16%2C%20Int32%2C%20etc.}

            for (int i = 0; i < numSearches; i++)
            {
                var result = results[i];

                Podcast p = null;

                try { 
                    p = await Podcast.BuildPodcastFromRSS(result.FeedUrl);
                    
                }catch { }



                if (p != null && p.Name != null && p.ImageURL != null && p.Author != null)
                {

                    await AddNewUserControl(p);
                }
            }



            Debug.WriteLine("(-) DONE SEARCHING");
        }

        private async void SearchBtn_ClickAsync(object sender, EventArgs e)
        {

            Search();

        }
    }
}
