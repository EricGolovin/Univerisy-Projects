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
    public partial class FabricSelectionForm : Form
    {
        private Models.FabricSelectionModel model = new Models.FabricSelectionModel();
        private Color pictureBoxBackColor;

        public FabricSelectionForm()
        {
            InitializeComponent();
            setUpLayout();
            model.load();
            pictureBoxBackColor = fabricPictureBox.BackColor;
        }

        public void SetSelectedModel(Networking.Independent.Model selectedModel) => model.selectedModel = selectedModel;

        private void setUpLayout()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            nextButton.Enabled = false;
        }

        private void FabricSelectionForm_Load(object sender, EventArgs e)
        {
            foreach (string title in model.getNames())
            {
                selectFabricComboBox.Items.Add(title);
            }
            nextButton.Enabled = true;
        }

        private void selectFabricComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeImageTo(model.getImageUrlFor(selectFabricComboBox.Text));
            nextButton.Enabled = true;
        }

        private void fabricPictureBox_Click(object sender, EventArgs e)
        {
            
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            model.sendData();

            List<Networking.MultipleDependable.Recommendation> resultList = Networking.MultipleDependable.RecommendationNetworkProxy.GetAll();
            foreach(Networking.MultipleDependable.Recommendation recommendation in resultList)
            {
                Console.WriteLine("--------------");
                Console.WriteLine($"model: {recommendation.model.name}");
                Console.WriteLine($"fabric: {recommendation.fabric.name}");
                Console.WriteLine("--------------");
            }
        }
        private void changeImageTo(string imageUrl)
        {
            fabricPictureBox.BackColor = pictureBoxBackColor;
            try
            {
                fabricPictureBox.Load("imageUrl");
            }
            catch (SystemException exception)
            {
                fabricPictureBox.BackColor = Color.DarkRed;
                Console.WriteLine(exception.Message);
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
