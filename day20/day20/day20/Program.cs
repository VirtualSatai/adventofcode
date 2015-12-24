using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day20
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input: 33100000

            /*
                House 1 got 10 presents.
                House 2 got 30 presents.
                House 3 got 40 presents.
                House 4 got 70 presents.
                House 5 got 60 presents.
                House 6 got 120 presents.
                House 7 got 80 presents.
                House 8 got 150 presents.
                House 9 got 130 presents.
             */


            int target = 33100000;
            int max = target / 33;
            var part1 = false;

            var houses = new int[max];

            for (int elf = 1; elf < max; elf++)
            {
                int cnt = part1 ? Int32.MinValue : 0;
                for (int house = elf; house < max && cnt < 50; house += elf)
                {
                    houses[house] += part1 ? elf * 10 : elf * 11;
                    cnt++;
                }
            }

            for (int i = 0; i < max; i++)
            {
                if (houses[i] >= target)
                {

                    Console.WriteLine(i + " " + houses[i]);
                    break;
                }
            }

        }
    }
}