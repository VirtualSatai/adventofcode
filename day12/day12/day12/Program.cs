using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day12
{
    class Program
    {
        static List<int> numbers = new List<int>();
        static void Main(string[] args)
        {

            foreach (string line in File.ReadLines("./input"))
            {

                GetAllNumbersInString(RemoveRedObjects(line));
            }

            Console.WriteLine(numbers.Sum());

        }

        static string RemoveRedObjects(string str)
        {
            string copy = new string(str.ToCharArray());
            for (int i = 0; i < str.Length - 2; i++)
            {
                if (str.Substring(i, 3) == "red")
                {
                    bool remove = true;
                    int objStartIndex = -1;
                    // find previous { if not in array
                    int arrEnds = 0;
                    int objEnds = 0;
                    for (int j = i; j >= 0; j--)
                    {
                        if (str[j] == ']')
                        {
                            arrEnds++;
                        }
                        else if (str[j] == '[')
                        {
                            arrEnds--;
                        }

                        if (arrEnds < 0)
                        {
                            // Was part of array
                            remove = false;
                            break;
                        }

                        if (str[j] == '}')
                        {
                            objEnds++;
                        }
                        else if (str[j] == '{')
                        {
                            objEnds--;
                        }

                        if (objEnds < 0)
                        {
                            objStartIndex = j;
                            break;
                        }
                    }

                    // find next }

                    int objEndIndex = 0;
                    // find previous { if not in array
                    int arrStarts = 0;
                    int objStarts = 0;
                    for (int j = i; j < str.Length; j++)
                    {
                        if (str[j] == ']')
                        {
                            arrEnds--;
                        }
                        else if (str[j] == '[')
                        {
                            arrEnds++;
                        }

                        if (arrEnds < 0)
                        {
                            // Was part of array
                            remove = false;
                            break;
                        }

                        if (str[j] == '}')
                        {
                            objStarts--;
                        }
                        else if (str[j] == '{')
                        {
                            objStarts++;
                        }

                        if (objStarts < 0)
                        {
                            objEndIndex = j;
                            break;
                        }
                    }

                    if (remove)
                    {
                        int start = objStartIndex;
                        int len = objEndIndex - objStartIndex + 1;
                        //Console.WriteLine("removed " + len + " chars");
                        //Console.WriteLine(copy.Substring(start,len));
                        copy = copy.Remove(start, len);
                        return RemoveRedObjects(copy);
                    }
                }
            }

            return copy;
        }

        static void GetAllNumbersInString(string str)
        {
            int tmpSum = 0;
            var numberStr = "";
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] >= '0' && str[i] <= '9') || str[i] == '-')
                {
                    numberStr += str[i];
                }
                else
                {
                    if (numberStr != "")
                    {
                        numbers.Add(Int32.Parse(numberStr));
                        numberStr = "";
                    }
                }

            }
        }
    }
}
