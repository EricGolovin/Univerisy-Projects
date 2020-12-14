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
        private Models.ModelSelectionModel model = new Models.ModelSelectionModel();
        public ModelSelectionForm()
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

        private void ModelSelectionForm_Load(object sender, EventArgs e)
        {
            foreach(string title in model.getNames()) {
                selectModelComboBox.Items.Add(title);
            }

        }

        private void selectModelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeImageTo(model.getImageUrlFor(selectModelComboBox.Text));
        }

        private void modelPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void nextButton_Click(object sender, EventArgs e)
        {

        }

        private void changeImageTo(string imageUrl)
        {
            modelPictureBox.Load("imageUrl");
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
