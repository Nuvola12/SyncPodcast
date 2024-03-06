using HonorsClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HonorsClient
{
    public class UserCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }


    public partial class LoginForm : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();

        private static readonly string serverUrl = "https://localhost:44390/api/user";

        public static async Task<string> Login(UserCredentials credentials)
        {
            var requestBody = JsonConvert.SerializeObject(credentials);
            var requestContent = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(serverUrl, requestContent);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Server returned error {response.StatusCode}");
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        public LoginForm()
        {
            InitializeComponent();

            
            passwordTextBox.PasswordChar = '*';
        }

        private async void loginBtn_Click(object sender, EventArgs e)
        {
            var credentials = new UserCredentials
            {
                Username = usernameTextBox.Text,
                Password = passwordTextBox.Text
            };

            try
            {
                var serverResponse = await Login(credentials);

                openMainForm(serverResponse);

                //MessageBox.Show(serverResponse, "Server Response", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openMainForm(string apiKey) {
            
                User.APIKey = apiKey;

                MainForm mainForm = new MainForm();
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();
                this.Hide();
            
        }
    }
}
