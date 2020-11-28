using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;

namespace NET_lab04
{
    public partial class Form1 : Form
    {
        private List<object> listOfBankClients = new List<object>();

        private DateTime defaultDate;
        private DateTime userSearchDate = new DateTime();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            defaultDate = dateTimePicker1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            parceXML("C:\\Users\\ericg\\Developer\\Univerisy-Projects\\net-subject\\NET-lab04\\NET-lab04\\BankData.xml");

            string textBoxText = "";
            foreach (BankClient client in listOfBankClients)
            {
                textBoxText += client.getDescription();
                textBoxText += "\r\n -\r\n";
            }
            if (textBoxText == "")
            {
                textBoxText = "Error: Could not parse xml file";
            }
            textBox1.Text = textBoxText;

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            userSearchDate = dateTimePicker1.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string textBoxText = "";
            textBoxText += $"Clients found: {userSearchDate.Date.ToString(System.Globalization.CultureInfo.CurrentCulture)}\r\n";
            foreach (BankClient client in listOfBankClients)
            {
                if (client.isDateEqualTo(userSearchDate))
                {
                    textBoxText += client.getDescription();
                    textBoxText += "\r\n-\r\n";
                }
            }
            if (textBoxText == "")
            {
                textBoxText = "No Clients were Found";
            }
            textBox1.Text = textBoxText;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void parceXML(string url)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(url);

            XmlNodeList depositors = xmlDoc.GetElementsByTagName("Depositor");
            XmlNodeList creditors = xmlDoc.GetElementsByTagName("Creditor");
            XmlNodeList organisations = xmlDoc.GetElementsByTagName("Organisation");

            for (int i = 0; i < depositors.Count; i++)
            {
                String name = depositors[i].ChildNodes.Item(0).InnerText;
                String date = depositors[i].ChildNodes.Item(1).InnerText;
                String debtAmount = depositors[i].ChildNodes.Item(2).InnerText;
                String debtPercent = depositors[i].ChildNodes.Item(3).InnerText;
                Depositor newDepositor = new Depositor(name, 
                    DateTime.Parse(date, System.Globalization.CultureInfo.InvariantCulture), 
                    Convert.ToDouble(debtAmount), 
                    Convert.ToInt32(debtPercent));
                this.listOfBankClients.Add(newDepositor);
            }
            for (int i = 0; i < creditors.Count; i++)
            {
                String name = creditors[i].ChildNodes.Item(0).InnerText;
                String date = creditors[i].ChildNodes.Item(1).InnerText;
                String creditAmount = creditors[i].ChildNodes.Item(2).InnerText;
                String creditPercent = creditors[i].ChildNodes.Item(3).InnerText;
                String balanceOwed = creditors[i].ChildNodes.Item(4).InnerText;
                Creditor newCreditor = new Creditor(name, 
                    DateTime.Parse(date, System.Globalization.CultureInfo.InvariantCulture), 
                    Convert.ToDouble(creditAmount),
                    Convert.ToInt32(creditPercent), 
                    Convert.ToDouble(balanceOwed));
                this.listOfBankClients.Add(newCreditor);
            }
            for (int i = 0; i < organisations.Count; i++)
            {
                String name = organisations[i].ChildNodes.Item(0).InnerText;
                String date = organisations[i].ChildNodes.Item(1).InnerText;
                String balanceNumber = organisations[i].ChildNodes.Item(2).InnerText;
                String amountOnAccount = organisations[i].ChildNodes.Item(3).InnerText;
                Organisation newOrganisation = new Organisation(name,
                    DateTime.Parse(date, System.Globalization.CultureInfo.InvariantCulture),
                    long.Parse(balanceNumber),
                    Convert.ToDouble(amountOnAccount));
                this.listOfBankClients.Add(newOrganisation);
            }
        }
    }

    public class BankClient
    {
        string name;
        DateTime openingDate;
        public BankClient(string name, DateTime openingDate)
        {
            this.name = name;
            this.openingDate = openingDate;
        }

        public bool isDateEqualTo(DateTime date)
        {
            DateTime openingDateWithoutTime = this.openingDate.Date;
            DateTime dateWithoutTime = date.Date;
            return openingDateWithoutTime.Equals(dateWithoutTime);
        }

        public virtual string getDescription()
        {
            return $"BankClient: Name -{this.name}-, Account Opening Date -{this.openingDate}-";
        }
    }

    public class SingleBankClient : BankClient
    {
        double amount;
        float percent;
        public SingleBankClient(string name, DateTime openingDate, double amount, float percent) : base(name, openingDate)
        {
            this.amount = amount;
            this.percent = percent;
        }

        public override string getDescription()
        {
            var bankClientDescription = base.getDescription();
            return $"Single{bankClientDescription}, Amount -{this.amount}-, Percent -{this.percent}-";
        }
    }

    public class Depositor : SingleBankClient
    {
        public Depositor(string name, DateTime openingDate, double amount, float percent) : base(name, openingDate, amount, percent) { }
        public override string getDescription()
        {
            var bankSingleClientDescription = base.getDescription();
            return $"Depositor{bankSingleClientDescription}";
        }
    }
    public class Creditor : SingleBankClient
    {
        double balanceOwed;
        public Creditor(string name, DateTime openingDate, double amount, float percent, double balanceOwed) : base(name, openingDate, amount, percent) {
            this.balanceOwed = balanceOwed;
        }

        public override string getDescription()
        {
            var bankSingleClientDescription = base.getDescription();
            return $"Creditor{bankSingleClientDescription}, BalancedOwed -{this.balanceOwed}-";
        }
    }

    public class Organisation : BankClient
    {
        long balanceNumber;
        double amountOnAccount;
        public Organisation(string name, DateTime openingDate, long balanceNumber, double amountOnAccount) : base(name, openingDate)
        {
            this.balanceNumber = balanceNumber;
            this.amountOnAccount = amountOnAccount;
        }

        public override string getDescription()
        {
            var bankClientDescription = base.getDescription();
            return $"Organisation{bankClientDescription}, Balance Number -{this.balanceNumber}-, Amount on Account -{this.amountOnAccount}-";
        }
    }
}
