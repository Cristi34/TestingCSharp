using System;
using System.IO;

namespace TestingCSharp
{
	public class ReadFile
    {
        /* sample reading from root Debug folder:
         * ReadFile.ReadProcessTxtFile(".//smsEnglish.txt"); 
         */
        public static void ReadProcessTxtFile(string filePath)
        {
            string[] stringSeparators = new string[] { "[sep]" };

            var lines = File.ReadLines(filePath);
            foreach (var line in lines)
            {
                var result = line.Split(stringSeparators, StringSplitOptions.None);
                var filename = result[0].Trim();
                var content = result[1].Trim();
                Console.WriteLine(filename + " sepparated " + content);
            }
        }
    }
}
