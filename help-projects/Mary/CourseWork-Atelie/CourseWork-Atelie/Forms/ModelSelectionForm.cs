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
    public partial class ModelSelectionForm : Form
    {
        public ModelSelectionForm()
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

        private void ModelSelectionForm_Load(object sender, EventArgs e)
        {

        }

        private void modelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void modelPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void nextButton_Click(object sender, EventArgs e)
        {

        }
    }
}
