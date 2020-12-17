using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork_Atelie.Forms
{
    public partial class DeleteFittingForm : Form
    {
        private Models.DeleteFittingModel model = new Models.DeleteFittingModel();
        public DeleteFittingForm()
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
            deleteButton.Enabled = false;
        }

        private void DeleteFittingForm_Load(object sender, EventArgs e)
        {
            foreach (string title in model.GetFittingFormattedIds())
            {
                fittingComboBox.Items.Add(title);
            }
        }

        private void fittingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            resultRichTextBox.Text = model.GetDescriptionForSelectedId(fittingComboBox.Text);
            deleteButton.Enabled = model.GetFittingSelectionStatus();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            model.DeleteObject();
        }

        private void resultRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Hide();
            new ManagerOperationForm().Show();
        }
    }
}
