using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day13
{
    class Person
    {
        public string name { get; set; }
        public List<Tuple<Person,int>> gainLoss = new List<Tuple<Person, int>>();  
    }
    class Program
    {
        static List<Person> people = new List<Person>();
        static void Main(string[] args)
        {
            foreach (string line in File.ReadLines("./input"))
            {
                var lineSplit = line.Remove(line.IndexOf('.')).Split(' ');
                if (!people.Any(x => x.name.Equals(lineSplit[0])))
                {
                    people.Add(new Person() { name = lineSplit[0] });
                }

                if (!people.Any(x => x.name.Equals(lineSplit[10])))
                {
                    people.Add(new Person() { name = lineSplit[10] });
                }

                var cnt = int.Parse(lineSplit[3]);
                if (lineSplit[2] == "lose")
                {
                    cnt = -cnt;
                }
                   
                var currentPerson = people.First(x => x.name == lineSplit[0]);
                var rSide = people.First(x => x.name == lineSplit[10]);

                currentPerson.gainLoss.Add(new Tuple<Person, int>(item1:rSide, item2:cnt));
            }

            GenerateAllRoutes(new List<Person>());

            int best = int.MinValue;
            foreach (var arangement in allarangements)
            {
                int currentValue = 0;
                for (int i = 0; i < arangement.Count; i++)
                {
                    currentValue += arangement[i].gainLoss.First(x => x.Item1 == arangement[(i + 1) % arangement.Count]).Item2;
                    currentValue += arangement[(i + 1) % arangement.Count].gainLoss.First(x => x.Item1 == arangement[i]).Item2;

                }

                if (currentValue > best)
                {
                    Console.WriteLine("New best: " + currentValue);
                    best = currentValue;
                }
            }

            allarangements = new List<List<Person>>();
            
            var me = new Person()
            {
                name = "me"
            };

            foreach (var p in people)
            {
                me.gainLoss.Add(new Tuple<Person, int>(item1:p, item2:0));
                p.gainLoss.Add(new Tuple<Person, int>(item1:me, item2:0));
            }

            people.Add(me);

            GenerateAllRoutes(new List<Person>());

            best = int.MinValue;
            foreach (var arangement in allarangements)
            {
                int currentValue = 0;
                for (int i = 0; i < arangement.Count; i++)
                {
                    currentValue += arangement[i].gainLoss.First(x => x.Item1 == arangement[(i + 1) % arangement.Count]).Item2;
                    currentValue += arangement[(i + 1) % arangement.Count].gainLoss.First(x => x.Item1 == arangement[i]).Item2;

                }

                if (currentValue > best)
                {
                    Console.WriteLine("New best with me: " + currentValue);
                    best = currentValue;
                }
            }

            return;
        }

        static List<List<Person>> allarangements = new List<List<Person>>();

        public static void GenerateAllRoutes(List<Person> loc)
        {
            if (loc.Count < people.Count)
            {
                foreach (var l in people.Where(x => !loc.Contains(x)))
                {
                    var list = new List<Person>();
                    list.AddRange(loc);
                    list.Add(l);
                    GenerateAllRoutes(list);
                }
            }
            else
            {
                allarangements.Add(loc);
            }
        }
    }
}
