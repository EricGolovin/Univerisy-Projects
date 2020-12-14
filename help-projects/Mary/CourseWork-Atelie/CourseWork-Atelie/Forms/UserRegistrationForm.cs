using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExtensionMethods;

namespace CourseWork_Atelie
{
    public partial class UserRegistrationForm : Form
    {
        private Models.UserRegistratioModel model = new Models.UserRegistratioModel();
        public UserRegistrationForm()
        {
            InitializeComponent();
            setUpLayout();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void setUpLayout()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            nextButton.Enabled = false;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            nextButton.Enabled = !areTextBoxesEmpty();
        }

        private void surnameTextBox_TextChanged(object sender, EventArgs e)
        {
            nextButton.Enabled = !areTextBoxesEmpty();
        }

        private void parentNameTextBox_TextChanged(object sender, EventArgs e)
        {
            nextButton.Enabled = !areTextBoxesEmpty();
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            nextButton.Enabled = !areTextBoxesEmpty();
        }

        private void phoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            nextButton.Enabled = !areTextBoxesEmpty();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            model.sendUser(nameTextBox.Text, surnameTextBox.Text, parentNameTextBox.Text, emailTextBox.Text, phoneNumberTextBox.Text);
            this.Hide();
            new ModelSelectionForm().Show();

            List<Networking.Independent.Client> clientList = Networking.Independent.ClientNetworkProxy.Get("SELECT * FROM CLIENT");
            foreach (Networking.Independent.Client client in clientList)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine(client.id);
                Console.WriteLine(client.fullName);
                Console.WriteLine(client.phoneNumber);
                Console.WriteLine(client.email);
                Console.WriteLine("-------------------");
            }
        }

        private bool areTextBoxesEmpty()
        {
            bool nameTextBoxIsEmpty = nameTextBox.Text.RemoveWhitespace() == "";
            bool surnameTextBoxIsEmpty = surnameTextBox.Text.RemoveWhitespace() == "";
            bool parentNameTextBoxIsEmpty = parentNameTextBox.Text.RemoveWhitespace() == "";
            bool emailTextBoxIsEmpty = emailTextBox.Text.RemoveWhitespace() == "@gmail.com" || emailTextBox.Text.RemoveWhitespace() == "";
            bool phoneNumberTextBoxIsEmpty = phoneNumberTextBox.Text.RemoveWhitespace() == "+380" || phoneNumberTextBox.Text.RemoveWhitespace() == "";
            return nameTextBoxIsEmpty ||
                surnameTextBoxIsEmpty ||
                parentNameTextBoxIsEmpty ||
                emailTextBoxIsEmpty ||
                emailTextBoxIsEmpty ||
                phoneNumberTextBoxIsEmpty;
        }
    }
}
