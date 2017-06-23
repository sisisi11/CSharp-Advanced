namespace _13.OfficeStuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class OfficeStuff
    {
        static void Main()
        {
            var lineNumbers = int.Parse(Console.ReadLine());

            var companiesAndProducts = new SortedDictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < lineNumbers; i++)
            {
                var lineParams = Console.ReadLine()
                    .Split(new[] { '-', ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
                var company = lineParams[0];
                var quantity = long.Parse(lineParams[1]);
                var product = lineParams[2];

                if (!companiesAndProducts.ContainsKey(company))
                {
                    companiesAndProducts.Add(company, new Dictionary<string, long>());
                }
                if (!companiesAndProducts[company].ContainsKey(product))
                {
                    companiesAndProducts[company].Add(product, 0);
                }

                companiesAndProducts[company][product] += quantity;
            }

            foreach (var company in companiesAndProducts)
            {
                Console.Write($"{company.Key}: ");

                Console.WriteLine(string.Join(", ", company.Value.Select(x => $"{x.Key}-{x.Value}")));
            }
        }
    }
}
