namespace _04.AshesOfRoses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class AshesOfRoses
    {

        public const string patternRegion = "^[A-Z][a-z]+$";
        public const string patternColor = "^[A-Za-z0-9]+$";

        static void Main()
        {
            var inputLine = Console.ReadLine();
            var rosesDictionary = new Dictionary<string, Dictionary<string, long>>();

            while (inputLine != "Icarus, Ignite!")
            {
                var inputArgs = inputLine.Split(new char[] { ' ' });

                long num;

                var isfirstWordValid = inputArgs[0];


                if (inputArgs.Length > 4)
                {
                    inputLine = Console.ReadLine();
                    continue;
                }
                if (isfirstWordValid != "Grow")
                {
                    inputLine = Console.ReadLine();
                    continue;
                }
                if (!inputArgs[1].StartsWith("<") || !inputArgs[1].EndsWith(">"))
                {
                    inputLine = Console.ReadLine();
                    continue;
                }
                if (!inputArgs[2].StartsWith("<") || !inputArgs[2].EndsWith(">"))
                {
                    inputLine = Console.ReadLine();
                    continue;
                }
                bool successfullyParsed = long.TryParse(inputArgs[3], out num);
                if (!successfullyParsed)
                {
                    inputLine = Console.ReadLine();
                    continue;
                }


                var regionName = inputArgs[1].Remove(0, 1).Remove(inputArgs[1].Length - 2, 1);
                var colorType = inputArgs[2].Remove(0, 1).Remove(inputArgs[2].Length - 2, 1);
                var roseAmount = long.Parse(inputArgs[3]);

                var regexforRegion = new Regex(patternRegion);
                var match = regexforRegion.Match(regionName);
                if (!match.Success)
                {
                    inputLine = Console.ReadLine();
                    continue;
                }

                var regexForColor = new Regex(patternColor);
                var match1 = regexForColor.Match(colorType);
                if (!match1.Success)
                {
                    inputLine = Console.ReadLine();
                    continue;
                }

                FillTheRosesDict(regionName, colorType, roseAmount, rosesDictionary);

                inputLine = Console.ReadLine();
            }
            Prlong(rosesDictionary);
        }

        private static void Prlong(Dictionary<string, Dictionary<string, long>> rosesDictionary)
        {
            var orderedRegions = rosesDictionary.OrderByDescending(pair => pair.Value.Values.Sum()).ThenBy(pair => pair.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var pair in orderedRegions)
            {
                var region = pair.Key;
                var colorsOfRose = pair.Value;
                var orderedColor = colorsOfRose.OrderBy(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

                Console.WriteLine($"{region}");
                foreach (var nestedPair in orderedColor)
                {
                    var color = nestedPair.Key;
                    var ammountOfRose = nestedPair.Value;
                    Console.WriteLine($"*--{color} | {ammountOfRose}");
                }

            }
        }

        private static void FillTheRosesDict(string regionName, string colorType, long roseAmount, Dictionary<string, Dictionary<string, long>> rosesDictionary)
        {
            if (!rosesDictionary.ContainsKey(regionName))
            {
                rosesDictionary.Add(regionName, new Dictionary<string, long>());
                rosesDictionary[regionName].Add(colorType, roseAmount);
            }
            else
            {
                if (!rosesDictionary[regionName].ContainsKey(colorType))
                {
                    rosesDictionary[regionName].Add(colorType, roseAmount);
                }
                else
                {
                    rosesDictionary[regionName][colorType] += roseAmount;
                }
            }
        }
    }
}