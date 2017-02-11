using System.Collections.Generic;
using System.Linq;

namespace Stats.Net
{
    public static class Summary {
        public static int Sum(IEnumerable<int> vector){
            return vector.Aggregate((a,b) => a+b);
        }
        public static double Mean(IEnumerable<int> vector){
            return (double)Sum(vector) / vector.Count();
        }
    }
}