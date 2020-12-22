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
using System.Threading;

namespace NET_lab02
{
    public partial class Form1 : Form
    {
        private List<int> numberList = new List<int>();
        private List<string> wordList = new List<string>();

        private List<char> lettersToCount = new List<char>() {'a', 'e', 'i', 'o', 'u'};
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
            parseDataToLists();

            ThreadStart numbersThreadReference = new ThreadStart(WriteMinMaxNumbers);
            Thread numbersThread = new Thread(numbersThreadReference);

            ThreadStart wordThreadReference = new ThreadStart(WriteWords);
            Thread wordsThread = new Thread(wordThreadReference);

            numbersThread.Start();
            wordsThread.Start();
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

        private void WriteMinMaxNumbers()
        {
            int minNumber = numberList.Last();
            int maxNumber = numberList.First();

            foreach(int number in numberList)
            {
                if (minNumber > number)
                {
                    minNumber = number;
                }
                if (maxNumber < number)
                {
                    maxNumber = number;
                }
            }
            WriteToTextBox($"minNumber=({minNumber}) _ maxNumber=({maxNumber})");
        }

        private void WriteWords()
        {
            List<KeyValuePair<string, int>> newWordPair = new List<KeyValuePair<string, int>>();

            KeyValuePair<string, int> resultWord = new KeyValuePair<string, int>("", 0);

            foreach (string word in wordList)
            {
                int vowelsCounter = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    if (lettersToCount.Contains(word[i]))
                    {
                        vowelsCounter++;
                    }
                }
                newWordPair.Add(new KeyValuePair<string, int>(word, vowelsCounter));
            }

            foreach(KeyValuePair<string, int> wordPair in newWordPair)
            {
                if (wordPair.Value > resultWord.Value)
                {
                    resultWord = wordPair;
                }
            }

            WriteToTextBox($"LargestWord=({resultWord.Key}) _ VovelsNumber=({resultWord.Value})");
        }

        private void parseDataToLists()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                char[] separator = { ' ', ';' };
                string[] words;

                FileInfo test_file = new FileInfo(openFileDialog1.FileName);
                FileStream fs = test_file.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader reader = new StreamReader(fs);

                string str = reader.ReadToEnd();

                reader.Close();
                fs.Close();

                words = str.Split(separator);

                foreach (String word in words)
                {
                    if (word != "")
                    {
                        if ((word[0] >= '0') && (word[0] <= '9'))
                        {
                            numberList.Add(Convert.ToInt32(word));
                        }
                        else
                        {
                            wordList.Add(word);
                        }
                    }
                }
            }
        }

        private void WriteToTextBox(string str)
        {
            Invoke((MethodInvoker)delegate
            {
                var oldText = textBox1.Text;
                textBox1.Text = $"{oldText} _________ {str}\r";
            });
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
