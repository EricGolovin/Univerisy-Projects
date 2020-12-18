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
    public partial class GetInfoForm : Form
    {
        private Models.GetInfoModel model = new Models.GetInfoModel();
        public GetInfoForm() 
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
            updateButton.Enabled = false;
            fittingIdComboBox.Enabled = false;
            getAllButton.Enabled = false;
        }

        private void GetInfoForm_Load(object sender, EventArgs e)
        {
            foreach(string typeName in model.GetAllTypes())
            {
                typeComboBox.Items.Add(typeName);
            }

            foreach (string typeName in model.GetAllFormattedFabricIds())
            {
                fittingIdComboBox.Items.Add(typeName);
            }
        }

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            model.SetSelectedType(typeComboBox.Text);
            fittingIdComboBox.Enabled = model.IsFabricSelected();
            getAllButton.Enabled = model.IsTypeSelected();
        }

        private void fittingIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            model.SetSelectedFitting(fittingIdComboBox.Text);
            if (model.IsFabricSelected())
            {
                resultRichTextBox.Text = "";
            }
            updateButton.Enabled = model.IsFabricSelected();

        }

        private void getAllButton_Click(object sender, EventArgs e)
        {
            resultRichTextBox.Text = model.GetFormattedInfo();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (resultRichTextBox.Text.RemoveWhitespace() != "")
            {
                string returedResult = model.UpdateFabric(resultRichTextBox.Text);
                if (returedResult == "")
                {
                    Hide();
                    new GetInfoForm().Show();
                } else
                {
                    resultRichTextBox.Text = returedResult;
                }
            }
            else
            {
                resultRichTextBox.Text = "Enter Value to Update to (delete that text before entering)";
            }

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
