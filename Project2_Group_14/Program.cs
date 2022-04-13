/*
    Name: Project 2
    Coders: Lee Hutson & James Hill
    Date: 2022-04-13
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Project2
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVFile csvFile = new CSVFile();
            List<string> InFix = new List<string>();
            string file = "Project 2_INFO_5101";
            InFix = csvFile.CSVDeserialize(file);

            
            PostfixConverter PostCon = new();
            List<string> PostFix = new();
            foreach (var i in InFix)
            {
                PostFix.Add(PostCon.converter(i));
            }

            PrefixConverter PreCon = new();
            List<string> PreFix = new();
            foreach(var i in InFix)
            {
                PreFix.Add(PreCon.converter(i));
            }

            CompareExpressions compareExpressions = new();

            using (StreamWriter sw = new StreamWriter("xmlFile.xml"))
            {
                sw.WriteLine(XMLExtension.WriteStartDocument());
                sw.WriteLine($"{XMLExtension.WriteStartRootElement()}");

                //Summary Report
                Console.WriteLine("===============================================================================================");
                Console.WriteLine("\t\t\t\t\t\tSummary Report");
                Console.WriteLine("===============================================================================================");
                Console.WriteLine("|{0,5}|{1,20}|{2,15}|{3, 15}|{4, 12}|{5, 12}|{6, 8}|", "sno", "InFix", "PostFix", "PreFix", "PreFix Res", "PostFix Res", "Match");
                Console.WriteLine("===============================================================================================");

                int count = 1;
                for (var i = 2; i < InFix.Count; i++)
                {
                    if (!(i % 2 == 0))
                    {
                        //Element
                        sw.WriteLine($"\t{XMLExtension.StartElement()}");
                        //count
                        Console.Write("|{0,5}|", count);
                        sw.WriteLine($"\t\t{InFix[0].WriteAttribute(count.ToString())}");
                        //infix
                        Console.Write("{0,20}|", InFix[i]);
                        sw.WriteLine($"\t\t{InFix[1].WriteAttribute(InFix[i])}");
                        //postfix
                        Console.Write("{0, 15}|", PostFix[i]);
                        sw.WriteLine($"\t\t{"postfix".WriteAttribute(PostFix[i])}");
                        //prefix
                        Console.Write("{0,15}|", PreFix[i]);
                        sw.WriteLine($"\t\t{"prefix".WriteAttribute(PreFix[i])}");
                        //pre res
                        var arrayPre = PreFix[i].ToCharArray();
                        var result1 = Evaluator.EvaluatePreFix(arrayPre);                  
                        Console.Write("{0,12}|", result1);
                        sw.WriteLine($"\t\t{"evaluation".WriteAttribute(result1)}");
                        //post res
                        var arrayPost = PostFix[i].ToCharArray();
                        var result2 = Evaluator.EvaluatePostFix(arrayPost);
                        Console.Write("{0,12}|", result2);                        
                        //compare
                        var match = compareExpressions.Compare(result1, result2);
                        Console.WriteLine("{0,8}|", match);
                        sw.WriteLine($"\t\t{"comparison".WriteAttribute(match.ToString())}");

                        sw.WriteLine($"\t{XMLExtension.WriteEndElement()}");

                        count++;
                    }
                }
                sw.WriteLine($"{XMLExtension.WriteEndRootElement()}");

            }
            Process.Start(new ProcessStartInfo
            {
                FileName = "xmlFile.xml",
                UseShellExecute = true,
                
            });
            
        }
    }
}
