using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace day19
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("./input");
            var rules = input.Where(x => x.Contains("=>"));
            var startString = input.Last();

            foreach (var rule in rules)
            {
                Console.WriteLine(rule);
            }

            //Console.WriteLine(PartOne(rules, startString));
            
            PartTwo(rules, startString);
        }

        static int PartOne(IEnumerable<string> rules, string startString)
        {
            var posibleOutputs = new List<string>();
            foreach (var r in rules)
            {
                var split = r.Split(Convert.ToChar(" "));
                var ls = split.First();
                var rs = split.Last();

                for (int i = 0; i < startString.Length - ls.Length + 1; i++)
                {
                    if (startString.Substring(i, ls.Length) == ls)
                        posibleOutputs.Add(startString.Remove(i, ls.Length).Insert(i, rs));
                }
            }

            return posibleOutputs.Distinct().Count();
        }

        static void PartTwo(IEnumerable<string> rules, string endString)
        {
            var count = 0;
            // Greedy replace the each occurance, no garrentee it's the best way. 
            while (endString != "e")
            {
                foreach (var r in rules)
                {
                    var split = r.Split(Convert.ToChar(" "));
                    var ls = split.First();
                    var rs = split.Last();

                    if (endString.Contains(rs))
                    {
                        var regex = new Regex(rs);
                        endString = regex.Replace(endString, ls, 1);
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
