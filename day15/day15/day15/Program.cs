using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day15
{
    class Ingredient
    {
        public string name { get; set; }
        public int capacity { get; set; }
        public int durability { get; set; }
        public int flavor { get; set; }
        public int texture { get; set; }
        public int calories { get; set; }

    }

    class Program
    {
        static List<Ingredient> ingredients = new List<Ingredient>();

        static void Main(string[] args)
        {
            foreach (string line in File.ReadLines("./input"))
            {
                var lineSplit = line.Replace(",", "").Split(' ');
                ingredients.Add(new Ingredient()
                {
                    name = lineSplit[0],
                    capacity = int.Parse(lineSplit[2]),
                    durability = int.Parse(lineSplit[4]),
                    flavor = int.Parse(lineSplit[6]),
                    texture = int.Parse(lineSplit[8]),
                    calories = int.Parse(lineSplit[10])
                });
            }

            genAllCombos(ingredients, 4);

            var currentBest = int.MinValue;
            foreach (var combo in AllCombos)
            {
                var capacity = 0;
                var durabillity = 0;
                var flavor = 0;
                var texture = 0;
                var calories = 0;


                foreach (var c in combo)
                {
                    capacity += c.Item2 * c.Item1.capacity;
                    durabillity += c.Item2 * c.Item1.durability;
                    flavor += c.Item2 * c.Item1.flavor;
                    texture += c.Item2 * c.Item1.texture;
                    calories += c.Item2*c.Item1.calories;
                }
                capacity = capacity < 0 ? 0 : capacity;
                durabillity = durabillity < 0 ? 0 : durabillity;
                flavor = flavor < 0 ? 0 : flavor;
                texture = texture < 0 ? 0 : texture;


                var value = capacity * durabillity * flavor * texture;

                var part2 = true;
                if (calories != 500 && part2)
                {
                    value = 0;
                }

                if (value > currentBest)
                {
                    currentBest = value;
                    Console.WriteLine(value);
                    Console.WriteLine(combo[0].Item1.name + " " + combo[0].Item2);
                    Console.WriteLine(combo[1].Item1.name + " " + combo[1].Item2);
                    Console.WriteLine(combo[2].Item1.name + " " + combo[2].Item2);
                    Console.WriteLine(combo[3].Item1.name + " " + combo[3].Item2);

                    Console.WriteLine(capacity);
                    Console.WriteLine(durabillity);
                    Console.WriteLine(flavor);
                    Console.WriteLine(texture);

                }
            }

            return;
        }

        static List<List<Tuple<Ingredient, int>>> AllCombos = new List<List<Tuple<Ingredient, int>>>();

        public static void genAllCombos(List<Ingredient> ingredientsIn, int numIngredients)
        {
            int derp = 0;
            for (int i = 1; i <= 100; i++)
            {
                List<Tuple<Ingredient, int>> deep = new List<Tuple<Ingredient, int>>();
                deep.Add(new Tuple<Ingredient, int>(ingredientsIn[0], i));
                for (int j = i; j <= 100 - i; j++)
                {
                    var deeper = new List<Tuple<Ingredient, int>>(deep);
                    deeper.Add(new Tuple<Ingredient, int>(ingredientsIn[1], j - i));

                    for (int k = j; k <= 100; k++)
                    {
                        var deeperer = new List<Tuple<Ingredient, int>>(deeper);
                        deeperer.Add(new Tuple<Ingredient, int>(ingredientsIn[2], k - j));


                        deeperer.Add(new Tuple<Ingredient, int>(ingredientsIn[3], 100 - k));

                        derp++;

                        if (k == 99)
                        {
                            derp++;
                        }
                        AllCombos.Add(deeperer);

                    }
                    if (j == 99)
                        derp++;
                }
                if (i == 99)
                    derp++;
            }
            Console.WriteLine(derp);
        }

    }
}
