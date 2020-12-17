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

namespace CourseWork_Atelie.Forms
{
    public partial class AddFittingForm : Form
    {
        private Models.AddFittingModel model = new Models.AddFittingModel();
        public AddFittingForm()
        {
            InitializeComponent();
            model.load();
            setUpLayout();
        }

        private void setUpLayout()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            addButton.Enabled = false;
        }

        private void AddFittingForm_Load(object sender, EventArgs e)
        {
            foreach(string title in model.GetBookingFormattedIds())
            {
                bookingIdComboBox.Items.Add(title);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bookingIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            resultRichTextBox.Text = model.GetDescriptionForSelectedId(bookingIdComboBox.Text);
            if (model.GetBookingSelectionStatus())
            {
                addButton.Enabled = true;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            model.SendObject();
            Hide();
            new AddFittingForm().Show();
        }

        private void resultRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void commentTextBox_TextChanged(object sender, EventArgs e)
        {
            model.SetComment(commentTextBox.Text);
            if (commentTextBox.Text.RemoveWhitespace() != "" && model.GetBookingSelectionStatus())
            {
                addButton.Enabled = true;
            } else
            {
                addButton.Enabled = false;
            }
        }

        private void exitButton_Click_1(object sender, EventArgs e)
        {
            Hide();
            new ManagerOperationForm().Show();
        }
    }
}
