using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork_BusSchedule.Views.UserFlow
{

    public partial class DetailsForm : Form
    {
        private struct Consts
        {
            public static string kGreeting = "Hello, {0}";
        }
        Models.DetailsModel model = new Models.DetailsModel();
        public DetailsForm()
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

            dateTimePicker.Value = DateTime.Now;
            greetingLabel.Text = String.Format(Consts.kGreeting, model.GetUserPositionAndName());
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            richTextBox.Text = model.GetItineraryForDate(dateTimePicker.Value);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            new Registration.RegistrationForm().Show();
            this.Close();
        }
    }
}
