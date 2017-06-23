namespace _08.MapDistricts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MApDistrict
    {
        static void Main()
        {
            var inputLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var population = long.Parse(Console.ReadLine());

            var cityAndPop = new Dictionary<string, List<long>>();

            foreach (var input in inputLine)
            {
                var inputArgs = input.Split(':').ToList();

                var cityName = inputArgs[0];
                var popOfCity = long.Parse(inputArgs[1]);

                if (!cityAndPop.ContainsKey(cityName))
                {
                    cityAndPop.Add(cityName, new List<long>());
                    cityAndPop[cityName].Add(popOfCity);
                }
                else
                {
                    cityAndPop[cityName].Add(popOfCity);
                }
            }

            var orderedCityAndPop = cityAndPop.OrderByDescending(p => p.Value.Sum())
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var pair in orderedCityAndPop)
            {
                if (pair.Value.Sum() > population)
                {
                    Console.WriteLine($"{pair.Key}: {string.Join(" ", pair.Value.OrderByDescending(v => v).Take(5))}");
                }
            }
        }
    }
}
