using System.Text;

namespace _13.SrybskoUnleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class SrybskoUnleashed
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, int>> venues = new Dictionary<string, Dictionary<string, int>>();
            var line = Console.ReadLine();

            while (line != "End")
            {
                var venueTokens = line.Split(new[] { " @" }, StringSplitOptions.RemoveEmptyEntries);
                if (!(venueTokens.Length > 1))
                {
                    line = Console.ReadLine();
                    continue;
                }
                var singer = venueTokens[0];

                var venueAndTickets = venueTokens[1].Split(' ');
                int ticketPrice = 0;
                int ticketCount = 0;

                try
                {
                    ticketPrice = int.Parse(venueAndTickets[venueAndTickets.Length - 2]);
                    ticketCount = int.Parse(venueAndTickets[venueAndTickets.Length - 1]);

                }
                catch (Exception e)
                {
                    line = Console.ReadLine();
                    continue;
                }
                var venue = new StringBuilder();

                for (int i = 0; i < venueAndTickets.Length - 2; i++)
                {
                    venue.Append(venueAndTickets[i]);   // Vzimame Scenata ot inputa
                    venue.Append(" ");  // izugbvame space pri append
                }

                if (venues.ContainsKey(venue.ToString()))
                {
                    if (venues[venue.ToString()].ContainsKey(singer))
                    {
                        venues[venue.ToString()][singer] += ticketCount * ticketPrice;
                    }
                    else
                    {
                        venues[venue.ToString()].Add(singer, ticketCount * ticketPrice);
                    }
                }
                else
                {
                    venues[venue.ToString()] = new Dictionary<string, int> { { singer, ticketCount * ticketPrice } };
                }

                line = Console.ReadLine();
            }
            foreach (var venue in venues)
            {
                Console.WriteLine(venue.Key);
                foreach (var singer in venue.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}
