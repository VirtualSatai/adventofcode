using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace day18
{
    class Grid
    {
        private static List<string> current { get; set; }

    }
    class Program
    {
        private static List<string> current { get; set; }
        private static List<string> next { get; set; }

        static void Main(string[] args)
        {
            current = File.ReadAllLines("./input").ToList();

            Console.WriteLine("Initial state: ");
            PrintList(current);

            for (int i = 0; i < 100; i++)
            {
                current = GenerateNextGeneration(TransformPartTwo(current));
                Console.WriteLine("After {0} step{1}: ", i + 1, i == 0 ? "" : "s");
            }
            PrintList(TransformPartTwo(current));

            var cnt = 0;
            TransformPartTwo(current).ForEach(x => cnt += x.Count(y => y.Equals('#')));
            Console.WriteLine(cnt);
        }

        static List<string> GenerateNextGeneration(List<string> input)
        {
            var derp = new List<String>();

            for (var i = 1; i < input.Count - 1; i++)
            {
                var sb = new StringBuilder();
                for (var j = 1; j < input[i].Length - 1; j++)
                {
                    // Count number of #'s neighboring the current element. 
                    var cnt = 0;

                    cnt += input[i - 1].Substring(j - 1, 3).Count(x => x.Equals('#'));
                    cnt += input[i + 0].Substring(j - 1, 3).Count(x => x.Equals('#'));
                    cnt += input[i + 1].Substring(j - 1, 3).Count(x => x.Equals('#'));

                    if (input[i][j] == '.')
                    {
                        sb.Append(cnt == 3 ? '#' : '.');
                    }
                    else
                    {
                        sb.Append(cnt == 3 || cnt == 4 ? '#' : '.');
                    }
                }
                derp.Add(sb.ToString());
            }

            return derp;
        }

        static void PrintList(List<string> inputList)
        {
            foreach (var line in inputList)
            {
                Console.WriteLine(line);
            }
        }

        static List<string> Transform(IEnumerable<string> inputList)
        {
            var res = new List<string>();
            res.Add(new string('.', inputList.First().Length + 2));
            res.AddRange(inputList.Select(s => "." + s + "."));
            res.Add(new string('.', inputList.First().Length + 2));
            return res;
        }

        static List<string> TransformPartTwo(IEnumerable<string> inputList)
        {
            var res = Transform(inputList);

            var joined = String.Join("", res).ToCharArray();

            // Set #'s on magic locations!!
            joined[inputList.First().Length + 3] = '#';
            joined[(inputList.First().Length + 2) * 2 - 2] = '#';
            joined[(inputList.First().Length + 2) * (inputList.Count()) + 1] = '#';
            joined[(inputList.First().Length + 2) * (inputList.Count() + 1) - 2] = '#';

            var str = new String(joined);
            var len = inputList.First().Length + 2;

            var output = Enumerable.Range(0, str.Length / len).Select(i => str.Substring(i * len, len)).ToList();

            return output;
        }
    }
}
