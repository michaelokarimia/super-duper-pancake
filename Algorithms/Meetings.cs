using System;

namespace Algorithms
{
    public class Meetings
    {
        public static void Run()
        {

            var meetings = new double[][] {
                new double[] {13, 14},
                new double[] {12, 12.5},
                new double[] {12, 15},
                new double[] {13, 15},
                new double[] {14, 16},
                new double[] {13, 17}
            };

            var shortestDuration = double.MaxValue;
            double longestDuration = 0;

            foreach (var pair in meetings)
            {
                var duration = pair[1] - pair[0];
                if (duration > longestDuration)
                {
                    longestDuration = duration;
                }

                if (duration < shortestDuration)
                {
                    shortestDuration = duration;
                }
            }

            Console.WriteLine("Shortest meeting: {0}", shortestDuration);
            Console.WriteLine("Longest meeting: {0}", longestDuration);
        }
    }
}
