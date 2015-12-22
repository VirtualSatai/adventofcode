using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace day9
{
    class Pair
    {
        public string x { get; set; }
        public string y { get; set; }
        public int distance { get; set; }
    }
    class Program
    {
        static int distance(string x, string y)
        {
            var w = distances.FirstOrDefault(p => (p.x == x && p.y == y) || (p.x == y && p.y == x));
            if (w != null)
            {
                return w.distance;
            }

            return -1;
        }

        static List<string> locations = new List<string>();
        static List<Pair> distances = new List<Pair>();
        static void Main(string[] args)
        {

            foreach (string line in File.ReadLines("./input"))
            {
                var w = line.Split(' ');

                distances.Add(new Pair() { x = w[0], y = w[2], distance = int.Parse(w[4]) });

                if (locations.All(x => x != w[0]))
                {
                    locations.Add(w[0]);
                }

                if (locations.All(x => x != w[2]))
                {
                    locations.Add(w[2]);
                }
            }

            GenerateAllRoutes(new List<string>());
            var listOfRoutes = allRoutes;

            Console.WriteLine(listOfRoutes.Count());

            int shortesLen = int.MaxValue;
            string shortesRoute;

            int longestLen = int.MinValue;
            string longestRoute;

            foreach (var route in listOfRoutes)
            {

                int distanceSum = 0;
                for (int i = 0; i < route.Count - 1; i++)
                {
                    distanceSum += distance(route[i], route[i + 1]);
                }

                if (distanceSum < shortesLen)
                {
                    var route_string = string.Join(" ", route);

                    shortesRoute = route_string;
                    shortesLen = distanceSum;
                    Console.WriteLine("Yay! " + shortesRoute + " => " + shortesLen);
                }

                if (distanceSum > longestLen)
                {
                    var route_string = string.Join(" ", route);

                    longestLen = distanceSum;
                    longestRoute = route_string;
                    Console.WriteLine("Nay! " + longestRoute + " => " + longestLen);
                   
                }
             }


        }

        static List<List<string>> allRoutes = new List<List<string>>();

        public static void GenerateAllRoutes(List<string> loc)
        {
            if (loc.Count < locations.Count)
            {
                foreach (var l in locations.Where(x => !loc.Contains(x)))
                {
                    var list = new List<string>();
                    list.AddRange(loc);
                    list.Add(l);
                    GenerateAllRoutes(list);
                }
            }
            else
            {
                allRoutes.Add(loc);
            }
        }
    }
}
