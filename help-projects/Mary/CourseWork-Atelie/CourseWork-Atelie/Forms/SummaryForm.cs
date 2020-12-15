using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork_Atelie
{
    public partial class SummaryForm : Form
    {
        private Models.SummaryModel model = new Models.SummaryModel();

        public void SetClient(Networking.Independent.Client client) => model.configuredClient = client;
        public void SetRecommendation(Networking.MultipleDependable.Recommendation recommendation) => model.configuredRecommendation = recommendation;
        public SummaryForm()
        {
            InitializeComponent();
            setUpLayout();
        }

        private void setUpLayout()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void SummaryForm_Load(object sender, EventArgs e)
        {
            setupTitles();
            loadPicturesToPictureBoxes();
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void modelNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void bookingSumTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void orderDateTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void fabricNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            model.sendBooking();
        }

        private void loadPicturesToPictureBoxes()
        {
            try
            {
                modelPictureBox.Load(model.getModelPictureUrl());
            }
            catch (SystemException exception)
            {
                Console.WriteLine(exception.Message);
            }
            try
            {
                fabricPictureBox.Load(model.getFabricPictureUrl());
            }
            catch (SystemException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void setupTitles()
        {
            nameTextBox.Text = model.configuredClient.fullName;
            modelNameTextBox.Text = model.configuredRecommendation.model.name;
            fabricNameTextBox.Text = model.configuredRecommendation.fabric.name;
            bookingSumTextBox.Text = model.getBookingSum();
            orderDateTextBox.Text = model.getCurrentDate();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void modelPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void fabricPictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
