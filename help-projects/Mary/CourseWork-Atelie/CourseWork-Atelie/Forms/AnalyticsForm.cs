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
        public AnalyticsForm()
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

        private void AnalyticsForm_Load(object sender, EventArgs e)
        {

        }

        private void getOrderNumberForClientButton_Click(object sender, EventArgs e)
        {

        }

        private void getOrderNumberForCutterButton_Click(object sender, EventArgs e)
        {

        }

        private void getCutterAvailabilityButton_Click(object sender, EventArgs e)
        {

        }

        private void getManufacturerPopularityButton_Click(object sender, EventArgs e)
        {

        }

        private void getFabricPopularityButton_Click(object sender, EventArgs e)
        {

        }

        private void getModelPopularityButton_Click(object sender, EventArgs e)
        {

        }

        private void getBookingNumberButton_Click(object sender, EventArgs e)
        {

        }

        private void getOrdersSumButton_Click(object sender, EventArgs e)
        {

        }
    }
}
