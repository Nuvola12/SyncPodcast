using HonorsClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HonorsClient.UserControls
{
    public partial class SettingsUC : UserControl
    {
        private static SettingsUC _instance;

        public static SettingsUC Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SettingsUC();
                return _instance;
            }
        }
        public SettingsUC()
        {
            InitializeComponent();

            volumeTB.Scroll += (sender, e) =>
            {
                MediaController mc = MediaController.Instance;

                int volume = volumeTB.Value;
                float percentage = (float)volume / 100.0f;


                mc.setVolume((int)(percentage * 100));

            };
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
