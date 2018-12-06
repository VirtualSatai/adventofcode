using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day14
{
    class RainDeer
    {
        public string name { get; set; }
        public int speed { get; set; }
        public int moveingTime { get; set; }
        public int restTime { get; set; }
        public int score { get; set; }
        public int distance { get; set; }
    }
    class Program
    {
        static List<RainDeer> raindeers = new List<RainDeer>();
        static void Main(string[] args)
        {
            foreach (string line in File.ReadLines("./input"))
            {
                var lineSplit = line.Split(' ');
                var raindeer = new RainDeer()
                {
                    name = lineSplit[0],
                    speed = int.Parse(lineSplit[3]),
                    moveingTime = int.Parse(lineSplit[6]),
                    restTime = int.Parse(lineSplit[13])
                };

                raindeers.Add(raindeer);
            }



            foreach (var i in Enumerable.Range(1, 2503))
            {
                int max = int.MinValue;
                foreach (var r in raindeers)
                {
                    r.distance = movedAfter(r, i);
                    if (r.distance > max)
                        max = r.distance;
                }


                foreach (var r in raindeers.Where(x => x.distance == max))
                {
                    r.score++;
                }
            }

            foreach (var r in raindeers.OrderBy(x => x.score))
            {
                Console.WriteLine("{0}: {1} km/s {2} s {3} s  {4} km {5}", r.name, r.speed, r.moveingTime, r.restTime, movedAfter(r, 2503), r.score);
            }

            Console.WriteLine(raindeers.Sum(x => x.score));
        }

        static int movedAfter(RainDeer r, int time)
        {
            int distance;
            int period = r.moveingTime + r.restTime;

            var fullPeriods = time / period;

            if (time % period >= r.moveingTime)
                fullPeriods++;

            distance = fullPeriods * r.speed * r.moveingTime;

            distance += (time % period < r.moveingTime) ? r.speed * (time % period) : 0;

            return distance;
        }
    }
}
