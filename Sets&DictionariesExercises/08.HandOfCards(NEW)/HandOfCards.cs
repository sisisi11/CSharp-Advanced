namespace _08.HandOfCards_NEW_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class HandOfCards
    {
        static void Main()
        {
            var players = new Dictionary<string, HashSet<string>>();
            var handout = Console.ReadLine();

            while (!(handout.Equals("JOKER")))
            {
                var handOutTokens = handout.Split(':');
                var playersNmae = handOutTokens[0];
                var cards = handOutTokens[1].Split(',').Select(a => a.Trim()).ToArray(); // TRIM removes any symbol except letters

                if (players.ContainsKey(playersNmae))
                {
                    players[playersNmae].UnionWith(cards); // Union like Add

                }
                else
                {
                    players[playersNmae] = new HashSet<string>(cards);
                }
                handout = Console.ReadLine();
            }

            PrintPlayersAndScores(players);
        }

        private static void PrintPlayersAndScores(Dictionary<string, HashSet<string>> players)
        {
            foreach (var player in players)
            {
                var score = CalculateScore(player.Value);
                Console.WriteLine($"{string.Join(" ", players.Keys)}: {score}");
            }
        }

        private static int CalculateScore(HashSet<string> cards)
        {
            var totalScore = 0;
            foreach (var card in cards)
            {
                var type = card.Last();
                var power = card.Substring(0, card.Length - 1);

                int score;
                var isDigit = int.TryParse(power, out score); // ako e cifra IsDigit == true, ako ne e == False

                
                if (!isDigit)
                {
                    switch (power)
                    {
                        case "J":
                            score = 11;
                            break;
                        case "Q":
                            score = 12;
                            break;
                        case "K":
                            score = 13;
                            break;
                        case "A":
                            score = 14;
                            break;
                    }
                }

                switch (type)
                {
                    case 'S':
                        score *= 4;
                        break;
                    case 'H':
                        score *= 3;
                        break;
                    case 'D':
                        score *= 2;
                        break;
                    case 'C':
                        score *= 1;
                        break;
                }
                totalScore += score;
            }
            return totalScore;
        }
    }
}
