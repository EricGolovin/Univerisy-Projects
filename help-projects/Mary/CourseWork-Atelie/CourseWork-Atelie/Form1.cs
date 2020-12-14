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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Networking.Independent.ClientNetworkProxy.Add("SET IDENTITY_INSERT CLIENT ON INSERT INTO CLIENT (IN_CLIENT, FIO_CLIENT, PHONE, EMAIL) VALUES (21, 'Eric', '+380653452897', 'HGFTGEHJ@gmail.com');");
            List<Networking.Independent.Client> clientList = Networking.Independent.ClientNetworkProxy.Get("SELECT * FROM CLIENT");
            foreach(Networking.Independent.Client client in clientList)
            {
                Console.WriteLine(client.fullName);
            }
        }
    }
}
