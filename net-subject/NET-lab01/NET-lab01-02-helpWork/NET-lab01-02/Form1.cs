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
        private string enteredString = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void button1_Click_1(object sender, EventArgs e)
        {
            enteredString = textBox1.Text;
            textBox1.Text = enteredString + "\n" + "Words without nums: " + calculate_words(enteredString);
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private int calculate_words(string inputString) {
            string[] numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
            string [] separator = { ",", ".", ";", ":", " "};
            string[] words = inputString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            bool breakNumberFlag = false;
            int wordsCounter = words.Length;
            foreach (string element in words)
            {
                for (int i = 0; i < element.Length; i += 1)
                {
                    foreach (string number in numbers)
                    {
                        string letter = Char.ToString(element[i]);
                        if (number.Equals(letter))
                        {
                            wordsCounter -= 1;
                            breakNumberFlag = true;
                            break;
                        }
                    }
                    if (breakNumberFlag)
                    {
                        breakNumberFlag = !breakNumberFlag;
                        break;
                    }
                }
            }
            return wordsCounter;
        }
    }
}
