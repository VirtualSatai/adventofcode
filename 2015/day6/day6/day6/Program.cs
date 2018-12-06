using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace day6
{
    public class Point
    {
        public Point(int _x, int _y)
        {
            x = _x;
            y = _y;
            val = 0;
        }

        public int x;
        public int y;
        public int val { get; set; }
    }

    class Program
    {
        public static List<Point> points = new List<Point>();

        static int PartOne()
        {

            foreach (string line in File.ReadLines("./input"))
            {
                // Console.WriteLine("{0}", line);

                var line_content = line.Split(' ');
                if (line_content[0] == "turn")
                {
                    var onOff = line_content[1] == "on";
                    var x_min = int.Parse(line_content[2].Split(',')[0]);
                    var y_min = int.Parse(line_content[2].Split(',')[1]);

                    var x_max = int.Parse(line_content[4].Split(',')[0]);
                    var y_max = int.Parse(line_content[4].Split(',')[1]);

                    foreach (var p in points.Where(a => a.x >= x_min && a.y >= y_min && a.x <= x_max && a.y <= y_max))
                    {
                        p.val = onOff ? 1 : 0;
                    }


                }
                else
                {
                    var x_min = int.Parse(line_content[1].Split(',')[0]);
                    var y_min = int.Parse(line_content[1].Split(',')[1]);

                    var x_max = int.Parse(line_content[3].Split(',')[0]);
                    var y_max = int.Parse(line_content[3].Split(',')[1]);

                    foreach (var p in points.Where(a => a.x >= x_min && a.y >= y_min && a.x <= x_max && a.y <= y_max))
                    {
                        p.val = (p.val == 1) ? 0 : 1;
                    }

                }
            }

            return points.Sum(x => x.val);
        }

        static int PartTwo()
        {

            foreach (string line in File.ReadLines("./input"))
            {
                var line_content = line.Split(' ');
                if (line_content[0] == "turn")
                {
                    var onOff = line_content[1] == "on";
                    var x_min = int.Parse(line_content[2].Split(',')[0]);
                    var y_min = int.Parse(line_content[2].Split(',')[1]);

                    var x_max = int.Parse(line_content[4].Split(',')[0]);
                    var y_max = int.Parse(line_content[4].Split(',')[1]);

                    foreach (var p in points.Where(a => a.x >= x_min && a.y >= y_min && a.x <= x_max && a.y <= y_max))
                    {
                        p.val += onOff ? 1 : (p.val > 0 ? -1 : 0);
                    }


                }
                else
                {
                    var x_min = int.Parse(line_content[1].Split(',')[0]);
                    var y_min = int.Parse(line_content[1].Split(',')[1]);

                    var x_max = int.Parse(line_content[3].Split(',')[0]);
                    var y_max = int.Parse(line_content[3].Split(',')[1]);

                    foreach (var p in points.Where(a => a.x >= x_min && a.y >= y_min && a.x <= x_max && a.y <= y_max))
                    {
                        p.val += 2;
                    }

                }
            }

            return points.Sum(x => x.val);
        }

        static void Main(string[] args)
        {
            /* Generate board */
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    points.Add(new Point(i, j));
                }

            }

            Console.WriteLine("Part 1: " + PartOne());

            foreach (var p in points)
            {
                p.val = 0;
            }

            Console.WriteLine("Part 1: " + PartTwo());
        }
    }
}
