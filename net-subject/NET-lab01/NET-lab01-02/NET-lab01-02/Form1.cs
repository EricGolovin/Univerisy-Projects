using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NET_lab01_02
{
    public partial class Form1 : Form
    {
        private string strToProcess = "My word, my world, my idea.";
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains("my") || !textBox1.Text.Contains("My"))
            {
                textBox1.Text = strToProcess;
            }
            if (checkBox1.Checked)
            {
                textBox1.Text = change_my(textBox1.Text, "our");
            } else
            {
                textBox1.Text = change_my(textBox1.Text, textBox2.Text);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private string change_my(string sentence, string word)
        {
            string wordUppercased = word;
            StringBuilder sb = new StringBuilder(sentence, 100);
            sb.Replace("my", word);
            sb.Replace("My", uppercaseStr(word));
            return sb.ToString();
        }

        private string uppercaseStr(string str)
        {
            if (str.Length > 0)
            {
                char firstLetter = str[0];
                string resultStr = Char.ToString(firstLetter).ToUpper() + str.Remove(0, 1);
                return resultStr;
            }
            return "";
        }
    }
}
