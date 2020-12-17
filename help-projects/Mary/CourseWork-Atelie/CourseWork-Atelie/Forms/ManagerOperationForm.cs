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
    public partial class ManagerOperationForm : Form
    {
        public ManagerOperationForm()
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

        private void ManagerOperationForm_Load(object sender, EventArgs e)
        {

        }

        private void analyticsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AnalyticsForm().Show();
        }

        private void insertionAndDeletionButton_Click(object sender, EventArgs e)
        {

        }

        private void operationsOnFittingButton_Click(object sender, EventArgs e)
        {
            Hide();
            new Forms.FittingOperationsForm().Show();
        }
    }
}
