using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day11
{
    class Program
    {
        static void Main(string[] args)
        {
            string pw1 = IteratePasswords("hepxcrrq");
            string pw2 = IteratePasswords(Increment(pw1));

            Console.WriteLine("Part 1: " + pw1);
            Console.WriteLine("Part 2: " + pw2);


        }

        static string IteratePasswords(string startPassword)
        {
            var pw = startPassword;

            while (!validatePassword(pw))
            {
                pw = Increment(pw);
            }

            return pw;
        }

        static string Increment(string str)
        {
            var derp = str.ToCharArray();
            for (int i = derp.Length - 1; i > 0; i--)
            {
                if (derp[i] == 'z')
                {
                    derp[i] = 'a';
                }
                else
                {
                    derp[i]++;
                    break;
                }

            }

            return new string(derp);
        }

        static bool validatePassword(string password)
        {
            /*
            if (password.Length != 8)
                return false;

            if (password.ToLower() != password)
                return false;
            */

            // Req 2
            if (password.Any(x => x.Equals('i') || x.Equals('l') || x.Equals('o')))
                return false;

            // Req 1
            bool increasingThree = false;
            for (int i = 0; i < password.Length - 3; i++)
            {
                if (password[i] == password[i + 1] - 1 && password[i] == password[i + 2] - 2)
                    increasingThree = true;
            }

            if (!increasingThree)
                return false;

            // Req 3
            var numberOfPairs = 0;
            var firstPair = ' ';

            for (int i = 0; i < password.Length - 1; i++)
            {
                if (password[i] == password[i + 1] && password[i] != firstPair)
                {
                    numberOfPairs++;
                    firstPair = password[i];
                }
            }

            if (numberOfPairs < 2)
                return false;

            return true;
        }
    }
}
