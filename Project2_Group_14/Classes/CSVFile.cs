/*
    Name: Project 2
    Coders: Lee Hutson & James Hill
    Date: 2022-04-13
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace Project2
{
    public class CSVFile
    {
        public CSVFile()
        {

        }
        public List<string> CSVDeserialize(string filename)
        {
            List<string> CSVList = new List<string>();
            //separators
            char[] separators = new char[] { ',','\r', '\n' };

            if(File.Exists($"{filename}.csv"))
            {
                //Read the csv file
                string[] fileToArray = File.ReadAllText($"{filename}.csv").Split(separators,StringSplitOptions.RemoveEmptyEntries);

                //Deserialize the CSV string
                foreach(var f in fileToArray)
                {
                    CSVList.Add(f);
                }
                return CSVList;
            }
            else
            {
                Console.WriteLine("File doesnt exist");
                return null;
            }
        }
    }
}
