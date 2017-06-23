﻿namespace _10.HeiganDance
{
    using System;

    public class HeiganDance
    {
        private const int ChamberSize = 15;
        private const double CloudDamage = 3500;
        private const double EruptionDamage = 6000;
        private const double PlayerHealth = 18500;
        private const double HeiganHealth = 3000000;

        public static void Main()
        {
            var playerPos = new int[] { ChamberSize / 2, ChamberSize / 2 };  // masiv koito zadavame stoinost [7, 7] (polojenieto na player-a)
            var heiganPoints = HeiganHealth;
            var playerPoints = PlayerHealth;
            var isHeiganDead = false;
            var isPlayerDead = false;
            var hasCloud = false;
            var deathCause = string.Empty;

            var damageToHeigan = double.Parse(Console.ReadLine());

            while (true)
            {
                var spellTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var spell = spellTokens[0];
                var spellRow = int.Parse(spellTokens[1]);
                var spellCol = int.Parse(spellTokens[2]);

                heiganPoints -= damageToHeigan;
                isHeiganDead = heiganPoints <= 0;

                if (hasCloud)
                {
                    playerPoints -= CloudDamage;
                    hasCloud = false;
                    isPlayerDead = playerPoints <= 0;
                }

                if (isHeiganDead || isPlayerDead)
                {
                    break;
                }

                if (IsPlayerInDamagedZone(playerPos, spellRow, spellCol))
                {
                    if (!PlayerTryEscape(playerPos, spellRow, spellCol))
                    {
                        switch (spell)
                        {
                            case "Cloud":
                                playerPoints -= CloudDamage;
                                hasCloud = true;
                                deathCause = "Plague Cloud";
                                break;
                            case "Eruption":
                                playerPoints -= EruptionDamage;
                                deathCause = spell;
                                break;
                        }
                    }
                }
                isPlayerDead = playerPoints <= 0;
                if (isPlayerDead)
                {
                    break;
                }
            }
            PrintResult(playerPos, heiganPoints, playerPoints, deathCause);
        }

        private static void PrintResult(int[] playerPos, double heiganPoints, double playerPoints, string deathCause)
        {
            if (heiganPoints <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heiganPoints:f2}");
            }
            if (playerPoints <= 0)
            {
                Console.WriteLine($"Player: Killed by {deathCause}");
            }
            else
            {
                Console.WriteLine($"Player: {playerPoints}");
            }
            Console.WriteLine($"Final position: {playerPos[0]}, {playerPos[1]}");
        }

        private static bool PlayerTryEscape(int[] playerPos, int spellRow, int spellCol)
        {
            if (playerPos[0] - 1 >= 0 && playerPos[0] - 1 < spellRow - 1)
            {
                playerPos[0] -= 1;
                return true;
            }
            else if (playerPos[1] + 1 < ChamberSize && playerPos[1] + 1 > spellCol + 1)
            {
                playerPos[1] += 1;
                return true;
            }
            else if (playerPos[0] + 1 < ChamberSize && playerPos[0] + 1 > spellRow + 1)
            {
                playerPos[0] += 1;
                return true;
            }
            else if (playerPos[1] - 1 >= 0 && playerPos[1] - 1 < spellCol - 1)
            {
                playerPos[1] -= 1;
                return true;
            }
            return false;
        }

        private static bool IsPlayerInDamagedZone(int[] playerPos, int spellRow, int spellCol)
        {
            bool isHitRow = playerPos[0] >= spellRow - 1 && playerPos[0] <= spellRow + 1;
            bool isHitCol = playerPos[1] >= spellCol - 1 && playerPos[1] <= spellCol + 1;

            return isHitCol && isHitRow;
        }
    }
}
