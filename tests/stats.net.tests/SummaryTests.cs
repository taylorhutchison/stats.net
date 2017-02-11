using Xunit;
using Stats.Net;
using static Stats.Net.Summary;

namespace Stats.Net.Tests {
    
    public class SummaryTests {

        [Fact]
        public void Summary_Sum_Test(){
            int[] data = new int[] {1,2,3,4};
            var sum = Sum(data);
            Assert.Equal(10,sum);
        }

        [Fact]
        public void Summary_Mean_Test(){
            int[] data = new int[]{1,2,3,4};
            var mean = Mean(data);
            Assert.Equal(2.5, mean);
        }
    }

}

