using System;
using System.Collections.Generic;
using System.Linq;

namespace Project2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> InFix = new();
            InFix.Add("5+4");
            InFix.Add("4-3");
            InFix.Add("2*4");
            InFix.Add("8/2");
            InFix.Add("3/2");
            InFix.Add("9+9-8");
            InFix.Add("9-9*3");
            InFix.Add("4*5/2");
            InFix.Add("7*7*2-9");
            InFix.Add("5*2+8/2");
            InFix.Add("9*6*2/2+9");
            InFix.Add("5*1-2");
            InFix.Add("6/3*5/2*8*3");
            InFix.Add("9-3+8-2/2*4");
            InFix.Add("9-2+7/2*8-6*7");
            InFix.Add("(7-3)*9+6");
            InFix.Add("7*2+(3*3)");
            InFix.Add("(7+9+6)*5-(2*2)");
            InFix.Add("(3*7+4)-4+1*2+(6/3)");
            InFix.Add("8*9-5/1+9*(1-3)");
            InFix.Add("(9*8)+(5*3)");
            InFix.Add("8*3-6+8-2+(2-1)");
            InFix.Add("9-6+8*2+8-3");
            InFix.Add("8*6-5*8+3*2/1");
            InFix.Add("9*9/3+5/5*5");
            PrefixConverter PreCon = new();
            List<string> PreFix = new();
            foreach (var s in InFix)
                PreFix.Add(PreCon.converter(s));
            Console.WriteLine("\nInfix:");
            foreach(var s in InFix)
                Console.WriteLine(s);
            Console.WriteLine("\nPostfix");
            foreach(var s in PreFix)
                Console.WriteLine(s);
            foreach (var s in PreFix)
            {
                char[] temp = s.ToCharArray();
                Console.WriteLine(Evaluator.EvaluatePreFix(temp));
            }
        }
    }
}
