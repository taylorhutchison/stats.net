using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StatsNet
{
    public static class Transforms
    {
        public static IEnumerable<double> Normalize(IEnumerable<double> vector)
        {
            var min = vector.Min();
            var max = vector.Max();
            return vector.Select(i =>
            {
                return (i - min) / (max - min);
            });
        }
    }
}
