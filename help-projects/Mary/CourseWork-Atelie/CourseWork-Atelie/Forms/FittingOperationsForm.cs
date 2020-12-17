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
    public partial class FittingOperationsForm : Form
    {
        private Models.FittingOperationsModel model = new Models.FittingOperationsModel();
        public FittingOperationsForm()
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
        }

        private void FittingOperationsForm_Load(object sender, EventArgs e)
        {

        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            showAllResultTextBox.Text = model.GetAllFormattedFittings();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Hide();
            new AddFittingForm().Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Hide();
            new DeleteFittingForm().Show();
        }

        private void showAllResultTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Hide();
            new ManagerOperationForm().Show();
        }
    }
}
