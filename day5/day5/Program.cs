using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = 0;

            foreach (string line in File.ReadLines("./input"))
            {
                bool passed2 = false;
                for (int i = 0; i < line.Length - 2; i++)
                {
                    if (line[i] == line[i + 2])
                        passed2 = true;
                }

                bool passed1 = TestOne(line);

                if (passed1 && passed2)
                    count++;

            }

            Console.WriteLine(count);
        }

        static bool TestOne(string line)
        {
            for (int i = 0; i < line.Length - 1; i++)
            {
                var pair = (line[i].ToString() + line[i + 1].ToString());
                for (int j = i + 2; j < line.Length - 1; j++)
                {
                    var pair2 = (line[j].ToString() + line[j + 1].ToString());
                    if (pair == pair2)
                        return true;
                }

            }

            return false;
        }
    }
}
