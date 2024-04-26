using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_10CharpT.Third
{
    internal class Third
    {
        public static void ThirdTask()
        {
            string filepath = "D:\\CHsarp\\CHsarp_Lab9\\First.txt";
            string formul = File.ReadAllText(filepath);
            Formula formula = new Formula(formul);
            Console.WriteLine("Result: " + formula.Evaluate());
        }
        
    }
}
