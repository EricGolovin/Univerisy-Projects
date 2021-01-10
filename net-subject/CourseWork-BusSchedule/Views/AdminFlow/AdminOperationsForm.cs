using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork_BusSchedule.Views.AdminFlow
{
    public partial class AdminOperationsForm : Form
    {
        private struct Consts
        {
            public static string kGreeting = "Hello, {0}";
        }
        Models.AdminOperationsModel model = new Models.AdminOperationsModel();
        public AdminOperationsForm()
        {
            InitializeComponent();
            SetupLayout();
            SetupControls();
            model.Load();
        }

        public void SetCurrentCredentialsInfo(Networking.Models.CredentialsInfo credentials)
        {
            model.SetCredentialsInfo(credentials);
            SetupControls();
        }

        private void SetupLayout()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void SetupControls()
        {
            foreach(string title in model.allModels)
            {
                comboBox.Items.Add(title);
            }
            comboBox.Text = model.GetCurrentSelectedModelName();
            greetingLabel.Text = String.Format(Consts.kGreeting, model.GetAdminName());
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            richTextBox.Text = model.GetDataForSelectedModel();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            model.SetCurrentSelectedModelName(comboBox.Text);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            new Registration.RegistrationForm().Show();
            this.Close();
        }
    }
}
