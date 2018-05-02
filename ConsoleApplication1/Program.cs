using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            char[] initialSet = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
                'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            //Console.WriteLine(initialSet);

            string path = @"c:\temp\MyTest.txt";

            // Open the file to read from.
            string readText = File.ReadAllText(path);

            //Console.WriteLine(readText);

            int[] count = new int[initialSet.Length];

            foreach (char c in readText)
            {
                int j = Array.IndexOf(initialSet, c);
                if(j != -1)
                    count[j]++;
            }

            //for(int i=0;i<initialSet.Length;i++)
            //{
            //    Console.Write(initialSet[i]);
            //    Console.WriteLine(" : "+count[i]);
            //}


            double result = 0.0;
            int len = readText.Length;
            for(int i=0; i<count.Length;i++)
            {
                var frequency = (double)count[i] / len;
                if(frequency != 0)
                    result -= frequency * (Math.Log(frequency) / Math.Log(2));
            }

            Console.WriteLine("Text Entropy is: "+result);


            //encoding
            string[] encodingSet = { "1", "10", "11", "100", "101", "110", "111", "1000", "1001", "1010", "1011", "1100", "1101", "1111", "10000", "10001", "10010", "10011", "10100",
                "10101", "10110", "10111", "11000", "11001", "11010", "11011", "11100", "11101", "11111", "100000", "100001", "100010", "100011", "100100", "100101", "100110" };

            int[] sortedCopy = count.OrderBy(i => i).ToArray();
            Array.Reverse(sortedCopy);

            int countComp = 0;
            int countLetters = 0;

            for (int i=0;i<sortedCopy.Length;i++)
            {
                if (sortedCopy[i] != 0)
                {
                    countComp += sortedCopy[i] * encodingSet[i].Length;
                    countLetters++;
                }
            }

            //Console.WriteLine("count compression " + countComp+" Letters "+countLetters);

            int intialLength = readText.Length * 6;

            double result2 = (double)intialLength / (double)countComp;

            Console.WriteLine(result2);

            Console.ReadKey();
        }
    }
}
