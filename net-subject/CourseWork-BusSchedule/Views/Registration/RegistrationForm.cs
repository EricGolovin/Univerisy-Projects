using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseWork_BusSchedule.Extensions;

namespace CourseWork_BusSchedule.Views.Registration
{
    public partial class RegistrationForm : Form
    {
        private Models.RegistrationModel model = new Models.RegistrationModel();
        private Color usernameBackColor;
        private Color passwordBackColor;
        public RegistrationForm()
        {
            InitializeComponent();
            SetupLayout();
            model.Load();
            usernameBackColor = usernameTextBox.BackColor;
            passwordBackColor = passwordMaskedTextBox.BackColor;
            passwordMaskedTextBox.Enabled = false;
            loginButton.Enabled = false;
        }

        protected void SetupLayout()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            model.SetName(usernameTextBox.Text);
            if (usernameTextBox.Text.RemoveWhitespaces() == "")
            {
                passwordMaskedTextBox.Enabled = false;
                passwordMaskedTextBox.Text = "";
                
            } else
            {
                passwordMaskedTextBox.Enabled = true;
            }
        }

        private void passwordMaskedTextBox_TextChanged(object sender, EventArgs e)
        {
            model.SetPassword(passwordMaskedTextBox.Text);
            Console.WriteLine(passwordMaskedTextBox.Text);
            loginButton.Enabled = passwordMaskedTextBox.Text.RemoveWhitespaces() != "";
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (model.ValidateUser())
            {
                // TODO: Implement Activity Flow
            } else
            {
                StartFailureFlow();
            }
        }

        private void StartFailureFlow()
        {
            usernameTextBox.BackColor = Color.Red;
            passwordMaskedTextBox.BackColor = Color.Red;

            timer.Interval = 750;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            usernameTextBox.BackColor = usernameBackColor;
            passwordMaskedTextBox.BackColor = passwordBackColor;
        }


    }
}
