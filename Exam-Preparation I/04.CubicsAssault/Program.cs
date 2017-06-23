using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.CubicsAssault
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputLine = Console.ReadLine();

            var meteors = new Dictionary<string, long>() { { "Black", 0 }, { "Green", 0 }, { "Red", 0 } };
            var regionsAndMeteors = new Dictionary<string, Dictionary<string, long>>();

            while (inputLine != "Count em all")
            {
                var inputArgs = inputLine.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                FillTheRegionsDict(inputArgs, regionsAndMeteors, meteors);
                inputLine = Console.ReadLine();
            }
            Print(regionsAndMeteors);
        }

        private static void Print(Dictionary<string, Dictionary<string, long>> regionsAndMeteors)
        {
            var orderedRegions = regionsAndMeteors.OrderByDescending(pair => pair.Value["Black"]).ThenBy(pair => pair.Key.Length).ThenBy(pair => pair.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var pair in orderedRegions)
            {
                var region = pair.Key;
                var typeOfMeteor = pair.Value;
                var orderedColor = typeOfMeteor.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

                Console.WriteLine($"{region}");
                foreach (var nestedPair in orderedColor)
                {
                    var color = nestedPair.Key;
                    var ammountOfMeteor = nestedPair.Value;
                    Console.WriteLine($"-> {color} : {ammountOfMeteor}");
                }
            }
        }

        private static void FillTheRegionsDict(string[] inputArgs, Dictionary<string, Dictionary<string, long>> regionsAndMeteors, Dictionary<string, long> meteors)
        {
            meteors = new Dictionary<string, long>() { { "Black", 0 }, { "Green", 0 }, { "Red", 0 } };
            var regionName = inputArgs[0];
            var meteorType = inputArgs[1];
            var meteorAmount = long.Parse(inputArgs[2]);

            if (!regionsAndMeteors.ContainsKey(regionName))
            {
                regionsAndMeteors.Add(regionName, meteors);
                regionsAndMeteors[regionName][meteorType] += meteorAmount;
            }
            else
            {
                regionsAndMeteors[regionName][meteorType] += meteorAmount;
            }
            if (regionsAndMeteors[regionName]["Green"] >= 1000000)
            {
                long amountToIncr = regionsAndMeteors[regionName]["Green"] / 1000000;

                regionsAndMeteors[regionName]["Green"] %= 1000000;
                regionsAndMeteors[regionName]["Red"] += amountToIncr;

            }
            if (regionsAndMeteors[regionName]["Red"] >= 1000000)
            {
                long amountToIncr = regionsAndMeteors[regionName]["Red"] / 1000000;

                regionsAndMeteors[regionName]["Red"] %= 1000000;
                regionsAndMeteors[regionName]["Black"] += amountToIncr;
            }
        }
    }
}
