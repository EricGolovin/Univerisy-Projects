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
    public partial class AnalyticsForm : Form
    {
        private Models.AnalyticsFormModel model = new Models.AnalyticsFormModel();
        public AnalyticsForm()
        {
            InitializeComponent();
            setUpLayout();
            model.load();
        }

        private void setUpLayout()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            startDateTimePicker.Value = DateTime.Today;
            endDateTimePicker.Value = DateTime.Today.AddDays(7);
        }

        private void AnalyticsForm_Load(object sender, EventArgs e)
        {

        }

        private void getOrderNumberForClientButton_Click(object sender, EventArgs e)
        {
            resultRichTextBox.Text = model.getFormattedClientOrdersNumber();
        }

        private void getOrderNumberForCutterButton_Click(object sender, EventArgs e)
        {
            resultRichTextBox.Text = model.getFormattedCutterOrdersNumber();
        }

        private void getCutterAvailabilityButton_Click(object sender, EventArgs e)
        {
            resultRichTextBox.Text = model.getFormattedCutterAvailability();
        }

        private void getManufacturerPopularityButton_Click(object sender, EventArgs e)
        {
            resultRichTextBox.Text = model.getFormattedManufacturerPopularity();
        }

        private void getFabricPopularityButton_Click(object sender, EventArgs e)
        {
            resultRichTextBox.Text = model.getFormattedFabricPopularity();
        }

        private void getModelPopularityButton_Click(object sender, EventArgs e)
        {
            resultRichTextBox.Text = model.getFormattedModelPopularity();
        }

        private void getBookingNumberButton_Click(object sender, EventArgs e)
        {
            resultRichTextBox.Text = model.getFormattedBookingNumber(startDateTimePicker.Value, endDateTimePicker.Value);
        }

        private void getOrdersSumButton_Click(object sender, EventArgs e)
        {
            resultRichTextBox.Text = model.getFormattedOrdersSum(startDateTimePicker.Value, endDateTimePicker.Value);
        }

        private void resultRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void startDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            endDateTimePicker.MinDate = startDateTimePicker.Value;
        }

        private void endDateTimePicker_ValueChanged_1(object sender, EventArgs e)
        {
            startDateTimePicker.MaxDate = endDateTimePicker.Value;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Hide();
            new ManagerOperationForm().Show();
        }
    }
}
