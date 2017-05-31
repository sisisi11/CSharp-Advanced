namespace _05.HandsCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        static void Main()
        {
            string command = Console.ReadLine();
            Dictionary<string, List<string>> cards = new Dictionary<string, List<string>>();

            while (command != "JOKER")
            {
                string[] actions = command.Split(':').ToArray();
                string name = actions[0];
                List<string> cardsSeq = actions[1].Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (!cards.ContainsKey(name))
                {
                    cards.Add(name, new List<string>());
                }

                cards[name].AddRange(cardsSeq);

                command = Console.ReadLine();
            }

            PrintResult(cards);
        }

        private static void PrintResult(Dictionary<string, List<string>> cards)
        {
            foreach (var val in cards)
            {
                string name = val.Key;
                List<string> playerCards = val.Value;
                int result = 0;

                playerCards = playerCards.Distinct().ToList();

                foreach (var card in playerCards)
                {

                    string cardType = card.Substring(0, card.Length - 1);
                    int points = ExtractCardPoints(cardType);
                    string letterOfCard = card[card.Length - 1].ToString(); // Letter of the card S, H, or D.
                    int multiplicator = Multipliers(letterOfCard);
                    result += points * multiplicator;
                }
                Console.WriteLine($"{name}: {result}");
            }
        }

        private static int Multipliers(string letterOfCard)
        {
            int val = 0;

            switch (letterOfCard)
            {
                case "S": val = 4; break;
                case "H": val = 3; break;
                case "D": val = 2; break;
                default: val = 1; break;
            }

            return val;
        }

        private static int ExtractCardPoints(string cardType)
        {

            int result = 0;

            switch (cardType)
            {
                case "J":
                    result += 11;
                    break;
                case "Q":
                    result += 12;
                    break;
                case "K":
                    result += 13;
                    break;
                case "A":
                    result += 14;
                    break;
                default:
                    result = int.Parse(cardType);
                    break;
            }

            return result;
        }
    }
}