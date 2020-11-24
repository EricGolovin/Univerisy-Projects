using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetLab04_Mary
{
    public partial class Form1 : Form
    {

        List<object> listOfProducts = new List<object>();

        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                radioButton1.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton4.Checked = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            string textBoxText = "";
            if (radioButton1.Checked == true)
            {
                foreach (object product in listOfProducts)
                {
                    if (product is Toy)
                    {
                        Toy toyProduct = product as Toy;
                        textBoxText += toyProduct.getDescription();
                        textBoxText += "\r\n---------------------\r\n";
                    }
                }
            } else if (radioButton2.Checked == true)
            {
                foreach (object product in listOfProducts)
                {
                    if (product is Book)
                    {
                        if (product is Book)
                        {
                            Book bookProduct = product as Book;
                            textBoxText += bookProduct.getDescription();
                            textBoxText += "\r\n---------------------\r\n";
                        }
                    }
                }
            } else if (radioButton3.Checked == true)
            {
                foreach (object product in listOfProducts)
                {
                    if (product is SportEquipment)
                    {
                        if (product is SportEquipment)
                        {
                            SportEquipment sportEquipmentProduct = product as SportEquipment;
                            textBoxText += sportEquipmentProduct.getDescription();
                            textBoxText += ("\r\n---------------------\r\n");
                        }
                    }
                }
            } else if (radioButton4.Checked == true)
            {
                foreach (object product in listOfProducts)
                {
                    if (product is Toy)
                    {
                        Toy toyProduct = product as Toy;
                        textBoxText += toyProduct.getDescription();
                        textBoxText += "\r\n---------------------\r\n";
                    }
                    if (product is Book)
                    {
                        Book bookProduct = product as Book;
                        textBoxText += bookProduct.getDescription();
                        textBoxText += "\r\n---------------------\r\n";
                    }
                    if (product is SportEquipment)
                    {
                        SportEquipment sportEquipmentProduct = product as SportEquipment;
                        textBoxText += sportEquipmentProduct.getDescription();
                        textBoxText += "\r\n---------------------\r\n";
                    }
                }
                
            }

            textBox1.Text = textBoxText;

            if (textBox1.Text == "" && listOfProducts.Count != 0)
            {
                textBox1.Text = "Nothing Found";
            } else if (textBox1.Text == "")
            {
                textBox1.Text = "No items in the list";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            Random rnd = new Random();
            List<object> myList = new List<object>();
            for (int i = 0; i < 10; i++)
            {
                int newRandomPrice = rnd.Next(10, 100);
                int newRandomAge = rnd.Next(2, 8);
                Toy newToy = new Toy(newRandomPrice, $"toy{i + 1}", newRandomAge, $"{i * newRandomAge}-Corporation", $"some-{i + 2}");
                myList.Add(newToy);
            }
            for (int i = 0; i < 10; i++)
            {
                int newRandomPrice = rnd.Next(10, 100);
                int newRandomAge = rnd.Next(2, 8);
                Book newBook = new Book(newRandomPrice, $"toy{i + 1}", newRandomAge, $"{i * newRandomAge}-Corporation", $"Joh-{i + 2}");
                myList.Add(newBook);
            }
            for (int i = 0; i < 10; i++)
            {
                int newRandomPrice = rnd.Next(10, 100);
                int newRandomAge = rnd.Next(2, 8);
                SportEquipment newToy = new SportEquipment(newRandomPrice, $"toy{i + 1}", newRandomAge, $"{i * newRandomAge}-Corporation");
                myList.Add(newToy);
            }
            listOfProducts = myList.OrderBy(x => Guid.NewGuid()).ToList();

            string textBoxText = "";
            foreach (object product in listOfProducts)
            {
                if (product is Toy)
                {
                    Toy toyProduct = product as Toy;
                    textBoxText += toyProduct.getDescription();
                    textBoxText += "\r\n---------------------\r\n";
                }
                if (product is Book)
                {
                    Book bookProduct = product as Book;
                    textBoxText += bookProduct.getDescription();
                    textBoxText += "\r\n---------------------\r\n";
                }
                if (product is SportEquipment)
                {
                    SportEquipment sportEquipmentProduct = product as SportEquipment;
                    textBoxText += sportEquipmentProduct.getDescription();
                    textBoxText += "\r\n---------------------\r\n";
                }
            }
            textBox1.Text = textBoxText;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public class Product
    {
        public double price;
        public string name;
        public float allowedAgeToUseFrom;
        public Product(double price, string name, float allowedAgeToUseFrom)
        {
            this.price = price;
            this.name = name;
            this.allowedAgeToUseFrom = allowedAgeToUseFrom;
        }

        public virtual string getDescription()
        {
            return "Product";
        }
    }

    public class Toy : Product
    {
        string manufacturer;
        string material;
        public Toy(double price, string name, float allowedAgeToUseFrom, string manufacturer, string material) : base(price, name, allowedAgeToUseFrom)
        {
            this.manufacturer = manufacturer;
            this.material = material;
        }

        public override string getDescription()
        {
            return $"Toy - Name: {this.name}, price: {this.price}, Allowed age to use from: {this.allowedAgeToUseFrom}, Manufacturer: {this.manufacturer}, Material: {this.material}";
        }
    }

    public class Book : Product
    {
        string author;
        string publisher;
        public Book(double price, string name, float allowedAgeToUseFrom, string author, string publisher) : base(price, name, allowedAgeToUseFrom)
        {
            this.author = author;
            this.publisher = publisher;
        }

        public override string getDescription()
        {
            return $"Book - Name: {this.name}, price: {this.price}, Allowed age to use from: {this.allowedAgeToUseFrom}, Author: {this.author}, Publisher: {this.publisher}";
        }
    }
    
    public class SportEquipment : Product
    {
        string manufacturer;
        public SportEquipment(double price, string name, float allowedAgeToUseFrom, string manufacturer) : base(price, name, allowedAgeToUseFrom)
        {
            this.manufacturer = manufacturer;
        }

        public override string getDescription()
        {
            return $"Sport Equipment - Name: {this.name}, price: {this.price}, Allowed age to use from: {this.allowedAgeToUseFrom}, Manufacturer: {this.manufacturer}";
        }
    }
}
