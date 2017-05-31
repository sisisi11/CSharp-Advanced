namespace _10.PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class PopulationCounter
    {
        static void Main()
        {
            var countries = new Dictionary<string, Dictionary<string, long>>();
            var line = Console.ReadLine();

            while (line != "report")
            {
                var info = line.Split('|');
                var country = info[1];
                var city = info[0];
                long populationOfCity = long.Parse(info[2]);

                if (countries.ContainsKey(country))
                {
                    countries[country].Add(city, populationOfCity);
                }
                else
                {
                    var cities = new Dictionary<string, long>();
                    cities.Add(city, populationOfCity);
                    countries.Add(country, cities);
                }


                line = Console.ReadLine();
            }

            PrlongCountryCityAndPopulation(countries);
        }

        private static void PrlongCountryCityAndPopulation(Dictionary<string, Dictionary<string, long>> countries)
        {
            var orderedCountries = countries
                .OrderByDescending(pair => pair.Value.Values.Sum())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var pair in orderedCountries)
            {
                var country = pair.Key;
                var cities = pair.Value;
                var orderedCities = cities.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                Console.WriteLine($"{country} (total population: {orderedCities.Values.Sum()})");
                foreach (var nestedPair in orderedCities)
                {
                    var city = nestedPair.Key;
                    var populationOfcity = nestedPair.Value;
                    Console.WriteLine($"=>{city}: {populationOfcity}");
                }
            }
        }
    }
}
