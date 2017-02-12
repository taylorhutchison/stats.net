using System.Collections.Generic;
using System.Linq;

namespace Stats.Net
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

        public static IEnumerable<int> Mode(IEnumerable<int> vector){
            var valueOccurences = CountOccurences(vector);
            var max = valueOccurences.Select(v => v.Value).Max();
            return max == 1 ? null : valueOccurences.Where(v => v.Value == max).Select(v => v.Key);
        }

        public static IEnumerable<float> Mode(IEnumerable<float> vector){
            var valueOccurences = CountOccurences(vector);
            var max = valueOccurences.Select(v => v.Value).Max();
            return max == 1 ? null : valueOccurences.Where(v => v.Value == max).Select(v => v.Key);
        }

        public static IEnumerable<double> Mode(IEnumerable<double> vector){
            var valueOccurences = CountOccurences(vector);
            var max = valueOccurences.Select(v => v.Value).Max();
            return max == 1 ? null : valueOccurences.Where(v => v.Value == max).Select(v => v.Key);
        }


    }
}