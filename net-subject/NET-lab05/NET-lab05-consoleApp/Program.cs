using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace NET_lab05_consoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadExample threadExample = new ThreadExample(10000);
            threadExample.Start();
        }

        class ThreadExample
        {
            public string fileNameToSaveTo = "net-generatedFile";

            private Random randomGenerator = new Random();
            private int numberCount;

            private int minNumber;
            private int maxNumber;
            private bool numberAssigned = false;
            public ThreadExample(int numberCount)
            {
                this.numberCount = numberCount;
            }

            public int GetMinNumber()
            {
                if (numberAssigned)
                {
                    return this.minNumber;
                }
                Console.WriteLine("Error: minNumber was not initialized");
                return -1;
            }

            public int GetMaxNumber()
            {
                if (numberAssigned)
                {
                    return this.maxNumber;
                }
                Console.WriteLine("Error: maxNumber was not initialized");
                return -1;
            }

            public void Start()
            {
                Thread exampleThread = new Thread(StartWorkFlow);
                exampleThread.Start();
                Console.WriteLine("Start Thread");
            }

            private void StartWorkFlow()
            {
                CalculateMinMax();
                WriteToFile();
            }

            private void CalculateMinMax()
            {
                for(int i = 0; i < numberCount; i++)
                {
                    int randomNumber = GenerateRandomNumber();
                    if (!numberAssigned)
                    {
                        minNumber = randomNumber;
                        maxNumber = randomNumber;
                        numberAssigned = true;
                    } else
                    {
                        if (randomNumber < minNumber)
                        {
                            minNumber = randomNumber;
                        }
                        if (randomNumber > maxNumber)
                        {
                            maxNumber = randomNumber;
                        }
                    }
                }
            }

            private int GenerateRandomNumber()
            {
                return randomGenerator.Next(10000);
            }

            private void WriteToFile()
            {
                FileManagerMinMaxProxy.WriteNumbersToDocuments(new List<int>() { minNumber, maxNumber }, fileNameToSaveTo);
                Console.WriteLine("Finish: File Created");
            }
        }

        class FileManagerMinMaxProxy
        {
            private static FileManager fileManager = FileManager.shared;

            public static void WriteNumbersToDocuments(List<int> numbers, string fileName)
            {
                fileManager.WriteToDocuments(fileName, ConvertList(numbers));
            }

            public static void WriteNumbersTo(List<int> numbers, string filePath, string fileName)
            {
                fileManager.WriteTo(filePath, fileName, ConvertList(numbers));
            }

            private static string ConvertList(List<int> numbers)
            {
                int numCount = numbers.Count;

                if (numCount == 2)
                {
                    int minNum = numbers[0];
                    int maxNum = numbers[1];
                    if (minNum > maxNum)
                    {
                        int temp = maxNum;
                        maxNum = minNum;
                        minNum = temp;
                    }
                    return $"min = ({minNum}) ------ max = ({maxNum})";
                }

                string resultString = "";
                for (int i = 0; i < numCount; i++)
                {
                    resultString += $"[{i}] = ({numbers[i]} ------ )";
                }
                return resultString;
            }
        }

        class FileManager
        {
            public static FileManager shared = new FileManager();

            private string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            private FileManager() { }

            public void WriteToDocuments(string fileName, string dataString)
            {
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, $"{fileName}.txt")))
                {
                    outputFile.WriteLine(dataString);
                }
            }

            public void WriteTo(string filePath, string fileName, string dataString)
            {
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(filePath, $"{fileName}.txt")))
                {
                    outputFile.WriteLine(dataString);
                }
            }
        }
    }
}
