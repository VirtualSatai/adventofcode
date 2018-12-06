using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using day7;

namespace day7
{

    public class Wire
    {

        public static List<String> OPS = new List<String> { "NOT", "OR", "AND", "LSHIFT", "RSHIFT" };

        public Wire(String input)
        {
            name = input;
            value = 0;
            literal = false;
        }

        public UInt16 GetValue()
        {
            if (calculated)
            {
                return value;
            }

            UInt16 n;
            if (UInt16.TryParse(name, out n))
            {
                value = n;
                calculated = true;
                return n;
            }

            switch (op)
            {
                case "NOT":
                    value = (UInt16)~lval.GetValue();
                    break;
                case "OR":
                    value = (UInt16)(lval.GetValue() | rval.GetValue());
                    break;
                case "AND":
                    value = (UInt16)(lval.GetValue() & rval.GetValue());
                    break;
                case "LSHIFT":
                    value = (UInt16)(lval.GetValue() << rval.GetValue());
                    break;
                case "RSHIFT":
                    value = (UInt16)(lval.GetValue() >> rval.GetValue());
                    break;
                default:
                    value = lval.GetValue();
                    break;
            }
            calculated = true;
            return value;
        }

        public String name;
        public UInt16 value { get; set; }
        public Boolean calculated { get; set; }
        public Boolean literal { get; set; }
        public Wire lval { get; set; }
        public Wire rval { get; set; }
        public String op { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {

            var wires = new List<Wire>();
            var OPS = new List<String> { "NOT", "OR", "AND", "LSHIFT", "RSHIFT" };


            foreach (string line in File.ReadLines("./input"))
            {
                var w = line.Split(' ');
                foreach (var wire in w.Where(x => x != "->" && !OPS.Contains(x)))
                {
                    if (wires.All(x => x.name != wire))
                        wires.Add(new Wire(wire));
                }

                var res = wires.FirstOrDefault(x => x.name == w.Last());

                res.op = w.FirstOrDefault(x => OPS.Contains(x));

                switch (res.op)
                {
                    case "OR":
                    case "AND":
                        res.lval = wires.First(x => x.name == w[0]);
                        res.rval = wires.First(x => x.name == w[2]);
                        res.calculated = false;
                        break;
                    case "NOT":
                        res.lval = wires.First(x => x.name == w[1]);
                        res.calculated = false;
                        break;
                    case "LSHIFT":
                        res.lval = wires.First(x => x.name == w[0]);
                        res.rval = new Wire(w[2]) {value = UInt16.Parse(w[2]), calculated = true};
                        res.calculated = false;
                        break;
                    case "RSHIFT":
                        res.lval = wires.First(x => x.name == w[0]);
                        res.rval = new Wire(w[2]) {value = UInt16.Parse(w[2]), calculated = true};
                        res.calculated = false;
                        break;
                    default:
                        /* Literal! */
                        if (Regex.IsMatch(w[0], @"^[a-zA-Z]+$"))
                        {
                            res.lval = wires.First(x => x.name == w[0]);
                            res.calculated = false;
                        }
                        else
                        {
                            res.value = UInt16.Parse(w[0]);
                            res.literal = true;
                            res.calculated = true;
                        }

                        break;
                }

            }

            int a_val = wires.First(x => x.name == "a").GetValue();

            Console.WriteLine("Part 1 => a: " + a_val);

             /* Part 2: */

            foreach (var w in wires.Where(x => x.calculated && !x.literal))
            {
                w.calculated = false;
            }

            wires.First(x => x.name == "b").value = (UInt16) a_val;

            Console.WriteLine("Part 2 => a: " + wires.First(x => x.name == "a").GetValue());
        }
    }
}
