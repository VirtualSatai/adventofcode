using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace day23
{
    class Instruction
    {
        public string name { get; set; }
        public string lval { get; set; }
        public string rval { get; set; }
    }
    class Program
    {
        static List<Instruction> program = new List<Instruction>();
        static void Main(string[] args)
        {
            foreach (string line in File.ReadLines("./input"))
            {
                var linesplit = line.Split(' ');
                program.Add(new Instruction()
                {
                    name = linesplit[0],
                    lval = linesplit[1].Replace('+', ' ').Replace(',', ' ').Trim(),
                    rval = line.Contains(',') ? linesplit[2].Replace('+', ' ').Replace(',', ' ').Trim() : ""
                });
            }

            UInt64 reg_a = 1;
            UInt64 reg_b = 0;

            int pc = 0;

            while (pc < program.Count)
            {
                switch (program[pc].name)
                {
                    case "hlf":
                        if (program[pc].lval == "a")
                        {
                            reg_a /= 2;
                        }
                        else
                        {
                            reg_b /= 2;
                        }
                        pc++;
                        break;
                    case "tpl":
                        if (program[pc].lval == "a")
                        {
                            reg_a *= 3;
                        }
                        else
                        {
                            reg_b *= 3;
                        }
                        pc++;
                        break;
                    case "inc":
                        if (program[pc].lval == "a")
                        {
                            reg_a += 1;
                        }
                        else
                        {
                            reg_b += 1;
                        }
                        pc++;
                        break;
                    case "jmp":
                        pc += int.Parse(program[pc].lval);
                        break;
                    case "jie":
                        if (program[pc].lval == "a")
                        {
                            if (reg_a % 2 == 0)
                            {
                                pc += int.Parse(program[pc].rval);
                            }
                            else
                            {
                                pc++;
                            }
                        }
                        else
                        {
                            if (reg_b % 2 == 0)
                            {
                                pc += int.Parse(program[pc].rval);
                            }
                            else
                            {
                                pc++;
                            }
                        }
                        break;
                    case "jio":
                        if (program[pc].lval == "a")
                        {
                            if (reg_a == 1)
                            {
                                pc += int.Parse(program[pc].rval);
                            }
                            else
                            {
                                pc++;
                            }
                        }
                        else
                        {
                            if (reg_b == 1)
                            {
                                pc += int.Parse(program[pc].rval);
                            }
                            else
                            {
                                pc++;
                            }
                        }
                        break;
                }

                Console.WriteLine("pc: {0}\ta: {1}\tb:{2}", pc, reg_a, reg_b);
            }
        }
    }
}
