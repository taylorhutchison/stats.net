using System;
using System.Collections.Generic;
using System.Linq;

namespace StatsNet
{
    public static class Summary {
        public static int Sum(IEnumerable<int> vector){
            if(vector.Any()){
                return vector.Aggregate((a,b) => a+b);
            }
            return default(int);
        }

        public static float Sum(IEnumerable<float> vector){
            if(vector.Any()){
                return vector.Aggregate((a,b) => a+b);
            }
            return default(float);
        }

        public static double Sum(IEnumerable<double> vector){
            if(vector.Any()){
                return vector.Aggregate((a,b) => a+b);
            }
            return default(double);
        }

        public static double? Mean(IEnumerable<int> vector){
            if(vector.Any()){
                return (double)Sum(vector) / vector.Count();
            }
            return null;
        }

        public static double? Mean(IEnumerable<float> vector){
            if(vector.Any()){
                return (double)Sum(vector) / vector.Count();
            }
            return null;
        }

         public static double? Mean(IEnumerable<double> vector){
            if(vector.Any()){
                return (double)Sum(vector) / vector.Count();
            }
            return null;
        }

        private static IDictionary<T, int> CountOccurences<T>(IEnumerable<T> vector){
            IDictionary<T,int> values = new Dictionary<T, int>();
            foreach(var item in vector){
                if(values.Keys.Contains(item)){
                    values[item]++;
                }
                else {
                    values.Add(item, 1);
                }
            }
            return values;
        }

        public static IEnumerable<T> Mode<T>(IEnumerable<T> vector) where T: IComparable<T>{
            var valueOccurences = CountOccurences(vector);
            var max = valueOccurences.Select(v => v.Value).Max();
            return max == 1 ? null : valueOccurences.Where(v => v.Value == max).Select(v => v.Key);
        }

        public static (T Min, T Max)  Range<T>(IEnumerable<T> vector) where T: IComparable<T>{
            if(vector != null && vector.Any()){
                var first = vector.First();
                T min = first;
                T max = first;
                foreach(var item in vector)
                {
                    if(item.CompareTo(min) < 0)
                    {
                        min = item;
                    }
                    if(item.CompareTo(max) > 0)
                    {
                        max = item;
                    }
                }
                return (Min: min, Max: max);
            }
            throw new ArgumentNullException($"Cannot pass a null or empty array to the range method");
        }

        public static double StdDev(IEnumerable<double> vector)
        {
            var mean = Mean(vector);
            var squaredDiff = vector.Select(v => Math.Pow(v - (double)mean, 2));
            var squaredDiffMean = Mean(squaredDiff);
            return Math.Sqrt((double)squaredDiffMean);
        }

        public static double StdDev(IEnumerable<float> vector)
        {
            var mean = Mean(vector);
            var squaredDiff = vector.Select(v => Math.Pow(v - (float)mean, 2));
            var squaredDiffMean = Mean(squaredDiff);
            return Math.Sqrt((double)squaredDiffMean);
        }

        public static double StdDev(IEnumerable<int> vector)
        {
            var mean = Mean(vector);
            var squaredDiff = vector.Select(v => Math.Pow(v - (int)mean, 2));
            var squaredDiffMean = Mean(squaredDiff);
            return Math.Sqrt((double)squaredDiffMean);
        }


    }
}