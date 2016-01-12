using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            PrintList(current);
            PrintList(GenerateNextGeneration(Transform(current)));

        }

        static List<string> GenerateNextGeneration(List<string> input)
        {
            var derp = new List<String>();
           
            for (var i = 1; i < input.Count + 1; i++)
            {
                var sb = new StringBuilder();
                for (var j = 1; j < input[i].Length + 1; j++)
                {
                    if (input[i][j] == '.')
                    {
                        var cnt = 0;

                        for (int k = i - 1; k <= i + 1; k++)
                        {
                            for (int l = j - 1; l <= j + 1; l++)
                            {
                                cnt += input[k][l] == '#' ? 1 : 0;
                            }
                        }

                        sb.Append(cnt == 3 ? '#' : '.');
                    }
                    else
                    {
                        var cnt = -1;

                        for (int k = i - 1; k <= i + 1; k++)
                        {
                            for (int l = j - 1; l <= j + 1; l++)
                            {
                                cnt += input[k][l] == '#' ? 1 : 0;
                            }
                        }

                        sb.Append((cnt == 2 || cnt == 3) ? '#' : '.');
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
            res.Add(new string('.', inputList.First().Length));
            res.AddRange(inputList.Select(s => "." + s + "."));
            res.Add(new string('.', inputList.First().Length));
            return res;
        }


    }
}
