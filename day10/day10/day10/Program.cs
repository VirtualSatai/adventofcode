using System;
using System.Text;

namespace day10
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "1113222113";
            DateTime dt = DateTime.Now;

            for (int i = 1; i <= 50; i++)
            {
                input = NextStep(input);
                Console.WriteLine(i + "=>" + input.Length);
            }

            DateTime dt_2 = DateTime.Now;

            Console.WriteLine(dt_2 - dt);
        }

        static string NextStep(string s)
        {
            s += " ";
            var outputStringBuilder = new StringBuilder();
           
            var cnt = 1;
            var prev = s[0];

            for (var i = 1; i < s.Length; i++)
            {
                if (s[i] == prev)
                {
                    cnt++;
                }
                else
                {
                    outputStringBuilder.Append(cnt.ToString() + prev);
                    prev = s[i];
                    cnt = 1;
                }
            }

            return outputStringBuilder.ToString();
        }
    }
}
