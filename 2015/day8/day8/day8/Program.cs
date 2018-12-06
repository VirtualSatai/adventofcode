using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace day8
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        static void Part1()
        {
            int tsum = 0;
            int escsum = 0;

            foreach (string line in File.ReadLines("./input"))
            {
                tsum += line.Length;
                escsum += Regex.Unescape(line).Length - 2;

                //Console.WriteLine("{0} {1} {2} {3}", line, line.Length, Regex.Unescape(line).Substring(1, Regex.Unescape(line).Length - 2), Regex.Unescape(line).Length - 2);
            }

            int diff = tsum - escsum;

            Console.WriteLine(diff);
        }

        static void Part2()
        {
            int tsum = 0;
            int escsum = 0;

            foreach (string line in File.ReadLines("./input"))
            {
                tsum += line.Length;
                escsum += Regex.Escape(line.Replace("\"", "AA").Replace("\\", "BB")).Length + 2;

                //Console.WriteLine("{0} {1} {2} {3}", line, line.Length, Regex.Escape(line.Replace("\"", "AA").Replace("\\", "BB")), Regex.Escape(line.Replace("\"", "AA").Replace("\\", "BB")).Length + 2);
            }

            int diff = escsum - tsum;

            Console.WriteLine(diff);
        }
    }
}
