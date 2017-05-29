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
            var venues = new Dictionary<string, Dictionary<string, int>>();
            var line = Console.ReadLine();

            while (line != "END")
            {
                var venueTokens =  line.Split(new [] {" @" }, StringSplitOptions.RemoveEmptyEntries);
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
                    ticketPrice = int.Parse(venueAndTickets[venueAndTickets.Length - 1]);

                }
                catch (Exception e)
                {
                    line = Console.ReadLine();
                    continue;
                }
                var venue = new StringBuilder();
                for (int i = 0; i < venueAndTickets.Length - 2; i++)
                {
                    venue.Append(venueAndTickets[i]);
                }
                if (venues.ContainsKey(venue.ToString()))
                {
                    venues[venues.ToString()] = new Dictionary<string, int>{ {singer, ticketPrice*ticketCount} };
                }

                line = Console.ReadLine();
            }
        }
    }
}
