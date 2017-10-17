using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
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

            Console.ReadKey();
        }
    }

}
