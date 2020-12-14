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
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
            setUpLayout();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Networking.Independent.ClientNetworkProxy.Add("SET IDENTITY_INSERT CLIENT ON INSERT INTO CLIENT (IN_CLIENT, FIO_CLIENT, PHONE, EMAIL) VALUES (21, 'Eric', '+380653452897', 'HGFTGEHJ@gmail.com');");
            List<Networking.Independent.Client> clientList = Networking.Independent.ClientNetworkProxy.Get("SELECT * FROM CLIENT");
            foreach(Networking.Independent.Client client in clientList)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine(client.id);
                Console.WriteLine(client.fullName);
                Console.WriteLine(client.phoneNumber);
                Console.WriteLine(client.email);
                Console.WriteLine("-------------------");
            }
        }

        private void setUpLayout()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowDialog();
            /*
            usernameTextBox.AutoSize = false;
            passwordTextBox.AutoSize = false;
            usernameTextBox.Size = new System.Drawing.Size(435, 35);
            passwordTextBox.Size = new System.Drawing.Size(435, 35);
            */
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AuthorizationForm
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1178, 744);
            this.Name = "AuthorizationForm";
            this.Load += new System.EventHandler(this.AuthorizationForm_Load);
            this.ResumeLayout(false);

        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
