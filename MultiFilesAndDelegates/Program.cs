using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace MultiFilesAndDelegates
{
    delegate string myDelegate(string myStr, string tmp);
    class myClass
    {
        static private string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static private Regex regex1 = new Regex(@"(\d+)", RegexOptions.IgnoreCase);
        static private Regex regex2 = new Regex(@"[+/*-]", RegexOptions.IgnoreCase);
        static private string ReadText = myClass.ReadTaskFile("Task.txt");
        static private string a = "", result = "", b = "";
        static private string[] arrReadText;
        static private string[] SearchResults()
        {
            arrReadText = ReadText.Split('=');
            myDelegate calculator;          
            int count = 0;
            do
            {
                for (int i = count; i < arrReadText.Length - 1; i++)
                {
                    MatchCollection matches1 = regex1.Matches(arrReadText[i]);

                    a = Convert.ToString(matches1[0]);
                    b = Convert.ToString(matches1[1]);
                    MatchCollection matches2 = regex2.Matches(arrReadText[i]);
                    if (Convert.ToString(matches2[0]) == "*")
                    {
                        calculator = Class1.Multiply;
                        result = calculator(a, b);
                    }
                    else if (Convert.ToString(matches2[0]) == "/")
                    {
                        calculator = Class1.Divide;
                        result = calculator(a, b);
                    }
                    else if (Convert.ToString(matches2[0]) == "+")
                    {
                        calculator = Class1.Plus;
                        result = calculator(a, b);
                    }
                    else if (Convert.ToString(matches2[0]) == "-")
                    {
                        calculator = Class1.Minus;
                        result = calculator(a, b);
                    }
                    break;
                }
                arrReadText[count] += "= " + result;
                count++;
            } while (count < arrReadText.Length - 1);
            return arrReadText;
        }
        static public string ResultToString()
        {
            string[] arrReadText = SearchResults();
            string result = "";
            for (int i = 0; i < arrReadText.Length; i++)
            {
                result += arrReadText[i];
            }
            return result;
        }
        static public void PrintResults()
        {
            Console.WriteLine(ResultToString());
        }

        static private string ReadTaskFile(string fileName)
        {
            fileName = path + "\\" + fileName;
            string readText = File.ReadAllText(fileName);
            return readText;
        }
        static public void WriteTaskFile(string fileName, string text)
        {
            fileName = path + "\\" + fileName;
            File.WriteAllText(fileName, text);
        }
    }
    class Program
    {      
        static void Main(string[] args)
        {           
            string answer = myClass.ResultToString();
            string newFile = "TaskAnswer.txt";
            myClass.PrintResults();
            myClass.WriteTaskFile(newFile, answer);
        }
    }
}
