using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MultiFilesAndDelegates
{
    delegate void myDelegate(string myStr, string tmp);

    class Program
    {
        static void Main(string[] args)
        {
            string str = "";
            for (int i = 0; i < myClass.FindeNum().Length; i++)
            {
                str += myClass.FindeNum()[i];
            }
            myClass.WriteTaskFile("TaskAnswer.txt", str);
        }
    }
}
