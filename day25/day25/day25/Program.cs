using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day25
{
    class Code
    {
        public Int64 val { get; set; }
        public int x { get; set; }
        public int y { get; set; }

    }

    class Program
    {
        List<Code> codes = new List<Code>();
        static void Main(string[] args)
        {
            const Int64 start = 20151125;
            const Int64 modulus = 33554393;
            const Int64 multiplier = 252533;

            int local_col = 1;
            int local_row = 1;

            int startPos = 1;

            int goal_col = 3019;
            int goal_row = 3010;

            Int64 current = start;

            do
            {
                local_row--;
                local_col++;
                if (local_row == 0)
                {
                    local_row = local_col;
                    local_col = 1;
                }

                current = GenerateNext(current, modulus, multiplier);
                startPos++;

            } while (!(local_col == goal_col && local_row == goal_row));
            Console.WriteLine("({2},{3}){0}: {1}", startPos, current, local_row, local_col);

        }

        public static Int64 GenerateNext(Int64 start, Int64 modulus, Int64 multiplier)
        {
            return (start * multiplier) % modulus;
        }
    }
}
