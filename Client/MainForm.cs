using HonorsClient.Models;
using HonorsClient.UserControls;

namespace HonorsClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            openLibrary();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            openSearch();
        }

        private void LibraryBtn_Click(object sender, EventArgs e)
        {
            openLibrary();
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            openSettings();
        }

        private void openLibrary()
        {
            if (!windowPanel.Controls.Contains(LibraryUC.Instance))
            {
                LibraryUC.InitializeWithPanel(windowPanel);
                windowPanel.Controls.Add(LibraryUC.Instance);
                LibraryUC.Instance.Dock = DockStyle.Fill;
                LibraryUC.Instance.BringToFront();
                LibraryUC.Instance.reloadLibrary();
            }
            else
            {
                LibraryUC.Instance.reloadLibrary();
                LibraryUC.Instance.BringToFront();
            }

        }

        private void openSearch()
        {
            if (!windowPanel.Controls.Contains(SearchUC.Instance))
            {
                SearchUC.InitializeWithPanel(windowPanel);
                windowPanel.Controls.Add(SearchUC.Instance);
                SearchUC.Instance.Dock = DockStyle.Fill;
                SearchUC.Instance.BringToFront();
            }
            else
            {
                SearchUC.Instance.BringToFront();
            }
        }

        private void openSettings()
        {
            if (!windowPanel.Controls.Contains(SettingsUC.Instance))
            {
                windowPanel.Controls.Add(SettingsUC.Instance);
                SettingsUC.Instance.Dock = DockStyle.Fill;
                SettingsUC.Instance.BringToFront();
            }
            else
            {
                SettingsUC.Instance.BringToFront();
            }
        }
    }
}