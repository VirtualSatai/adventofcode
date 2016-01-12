using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day17
{
    static class Program
    {
        private static List<int> input { get; set; } 
        static void Main(string[] args)
        {
            input = new List<int>{11, 30, 47, 31, 32, 36, 3, 1, 5, 3, 32, 36, 15, 11, 46, 26, 28, 1, 19, 3};

            var output = GetPowerSet(input).Where(x => x.Sum() == 150);
            var minCount = output.Min(x => x.Count());


            Console.WriteLine("Part 1: " + output.Count());
            Console.WriteLine("Part 2: " + output.Count(x => minCount == x.Count()));
        }

        public static IEnumerable<IEnumerable<T>> GetPowerSet<T>(this IList<T> list)
        {
            return from m in Enumerable.Range(0, 1 << list.Count)
                   select
                       from i in Enumerable.Range(0, list.Count)
                       where (m & (1 << i)) != 0
                       select list[i];
        }
    }
}
