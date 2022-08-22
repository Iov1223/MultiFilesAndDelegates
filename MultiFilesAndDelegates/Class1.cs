using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace MultiFilesAndDelegates
{
    class myClass
    {
        static private string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static public string[] FindeNum()
        {
            string[] arrReadText = myClass.ReadTaskFile("Task.txt").Split('\n');
            //int[] aAndb = new int[arrReadText.Length];
            // int aAndb = 0;
            Regex regex1 = new Regex(@"(\d+)", RegexOptions.IgnoreCase);
            Regex regex2 = new Regex(@"[*+/-]", RegexOptions.IgnoreCase);
            int a = 0, b = 0, result = 0;
            for (int i = 0; i < arrReadText.Length; i++)
            {
                MatchCollection matches1 = regex1.Matches(arrReadText[i]);
                a = Convert.ToInt32(Convert.ToString(matches1[0]));
                b = Convert.ToInt32(Convert.ToString(matches1[1]));

                for (int j = 0; j < arrReadText[i].Length; j++)
                {
                    MatchCollection matches2 = regex2.Matches(arrReadText[j]);
                    if (Convert.ToString(matches2) == "*")
                        result = a * b;
                    else
                        if (Convert.ToString(matches2) == "/")
                        result = a / b;
                    else
                            if (Convert.ToString(matches2) == "+")
                        result = a + b;
                    else
                                if (Convert.ToString(matches2) == "-")
                        result = a - b;
                }
                    Convert.ToString(result);
                    arrReadText[i] += " " + result + "\n";
                
            }
            return arrReadText;
        }
        public static string ReadTaskFile(string fileName)
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
}
