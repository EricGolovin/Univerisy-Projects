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
        private Color pictureBoxBackColor;
        public ModelSelectionForm()
        {
            InitializeComponent();
            setUpLayout();
            model.load();
            pictureBoxBackColor = modelPictureBox.BackColor;
        }

        private void setUpLayout()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            nextButton.Enabled = false;
        }

        private void ModelSelectionForm_Load(object sender, EventArgs e)
        {
            foreach(string title in model.getNames()) {
                selectModelComboBox.Items.Add(title);
            }
            nextButton.Enabled = true;
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
            this.Hide();
            FabricSelectionForm fabricSelectionForm = new FabricSelectionForm();
            fabricSelectionForm.SetSelectedModel(model.getSelectedModel());
            fabricSelectionForm.Show();
        }

        private void changeImageTo(string imageUrl)
        {
            modelPictureBox.BackColor = pictureBoxBackColor;
            try
            {
                modelPictureBox.Load("imageUrl");
            } catch (SystemException exception)
            {
                modelPictureBox.BackColor = Color.DarkRed;
                Console.WriteLine(exception.Message);
            }
            
        }
    }
}
