namespace _06.TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class TruckTour
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<GasPump> pumps = new Queue<GasPump>();

            for (int i = 0; i < n; i++)
            {
                string[] pumpInfo = Console.ReadLine().Split();
                ulong ammountOfGas = ulong.Parse(pumpInfo[0]);
                ulong distanceToNext = ulong.Parse(pumpInfo[1]);

                var pump = new GasPump(distanceToNext, ammountOfGas, i);
                pumps.Enqueue(pump);
            }

            GasPump starterPump = null;
            bool completeJourney = false;
            while (pumps.Count > 0)
            {
                GasPump currentPump = pumps.Dequeue();
                pumps.Enqueue(currentPump);
                starterPump = currentPump;

                ulong gastInTank = currentPump.AmountOfGas;
                while (gastInTank > currentPump.DistanceToNext)
                {
                    gastInTank -= currentPump.DistanceToNext;

                    currentPump = pumps.Dequeue();

                    pumps.Enqueue(currentPump);
                    if (currentPump == starterPump)
                    {
                        completeJourney = true;
                        break;
                    }
                    gastInTank += currentPump.AmountOfGas;
                }
                if (completeJourney)
                {
                    Console.WriteLine(starterPump.IndexOfPump);
                    break;
                }

            }
        }
    }

    public class GasPump
    {
        public ulong DistanceToNext { get; set; }
        public ulong AmountOfGas { get; set; }
        public int IndexOfPump { get; set; }

        public GasPump(ulong distanceToNext, ulong amountOfGas, int indexOfPump)
        {
            this.DistanceToNext = distanceToNext;
            this.AmountOfGas = amountOfGas;
            this.IndexOfPump = indexOfPump;
        }
    }
}
