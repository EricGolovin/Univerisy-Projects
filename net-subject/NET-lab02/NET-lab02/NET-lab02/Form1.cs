using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NET_lab02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            generatefile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = "";
                FileInfo test_file = new FileInfo(openFileDialog1.FileName);
                FileStream fs = test_file.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader reader = new StreamReader(fs);
                string str = reader.ReadToEnd();
                reader.Close();
                fs.Close();
                char[] separator = { ' ', ';' };
                string[] words;
                words = str.Split(separator);
                int count = 0;
                int max = Int32.MinValue, min = Int32.MaxValue;
                foreach (String word in words)
                {
                    Console.WriteLine(word);
                    if (word != "")
                        if ((word[0] >= '0') && (word[0] <= '9'))
                        {
                            count++;
                            if (max < Convert.ToInt32(word))
                                max = Convert.ToInt32(word);
                            else if (min > Convert.ToInt32(word))
                                min = Convert.ToInt32(word);
                        }
                        else textBox1.Text += word + " ";
                }
                str = openFileDialog1.FileName;
                int i = str.Length - 1;
                for (; (i >= 0) && (str[i] != '\\'); i--) ;
                str = str.Remove(i + 1);
                str += "numbersResult.txt";
                fs = File.Open(str, FileMode.Create);
                StreamWriter writer = new StreamWriter(fs);
                writer.WriteLine("Numbers count = " + count.ToString());
                writer.Close();
                fs.Close();
                fs = File.Open(str, FileMode.Append);
                writer = new StreamWriter(fs);
                writer.WriteLine("min number = " + min.ToString());
                writer.WriteLine("max number = " + max.ToString());
                writer.Close();
                fs.Close();

            }
        }

        private void generatefile()
        {
            string str = "";
            Random a = new Random();
            int random;

            for (int i = 0; i < 1000; i++) {
                random = a.Next(2);
                if (random == 0) {
                    str += a.Next().ToString();
                } else {
                    int length = a.Next(8) + 1;
                    for (int k = 0; k < length; k++)
                        str += ((char)(a.Next(26) + 97)).ToString();
                }
                str += " ";
            }

            FileStream fs;
            StreamWriter writer;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                fs = File.Open(saveFileDialog1.FileName, FileMode.Create);
                writer = new StreamWriter(fs);
                writer.Write(str);
                writer.Close();
                fs.Close();
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
