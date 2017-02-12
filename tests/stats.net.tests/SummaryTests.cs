using Xunit;
using System;
using System.Collections.Generic;
using Stats.Net;
using System.Linq;
using static Stats.Net.Summary;

namespace Stats.Net.Tests
{

    public class SummaryTests
    {

        [Fact]
        public void Sum_GivenAnArrayOfInts_FindsTheCorrectSum()
        {
            int[] data = new int[] { 1, 2, 3, 4 };
            var sum = Sum(data);
            Assert.Equal(10, sum);
        }

        [Fact]
        public void Sum_GivenAnArrayOfFloats_FindsTheCorrectSum()
        {
            float[] data = new float[] { 1.7f, 2.2f, 3.9f, 4.3f };
            var sum = Sum(data);
            Assert.Equal(12.1, sum, 1);
        }

        [Fact]
        public void Sum_GivenAnArrayOfDoubles_FindsTheCorrectSum()
        {
            double[] data = new double[] { 1.7, 2.2, 3.9, 4.3 };
            var sum = Sum(data);
            Assert.Equal(12.1, sum, 1);
        }


        [Fact]
        public void Sum_GivenANullArray_FindsTheCorrectSum()
        {
            int[] data = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                var sum = Sum(data);
            });
        }

        [Fact]
        public void Sum_GivenAnEmptyArray_ReturnsZero()
        {
            int[] data = new int[0];
            var sum = Sum(data);
            Assert.Equal(0, sum);
        }

        [Fact]
        public void Mean_GivenAnArrayOfInts_ReturnsTheAverage()
        {
            int[] data = new int[] { 1, 2, 3, 4 };
            var mean = Mean(data);
            Assert.Equal(2.5, mean);
        }

        [Fact]
        public void Mean_GivenAnArrayOfFloats_ReturnsTheAverage()
        {
            float[] data = new float[] { 1.5f, 2.25f, 3.25f, 4.5f };
            var mean = Mean(data);
            Assert.Equal(2.875f, mean);
        }

        [Fact]
        public void Mean_GivenAnArrayOfDoubles_ReturnsTheAverage()
        {
            double[] data = new double[] { 1.5, 2.25, 3.25, 4.5 };
            var mean = Mean(data);
            Assert.Equal(2.875, mean);
        }

        [Fact]
        public void Mean_GivenAnEmptyList_ReturnsNull()
        {
            int[] data = new int[0];
            var mean = Mean(data);
            Assert.Null(mean);
        }

        [Fact]
        public void Mode_GivenAnArrayOfIntsWithASingleMode_ReturnsAListWithASingleElement()
        {
            int[] data = new int[] { 1, 2, 3, 4, 5, 5, 6, 7 };
            var mode = Mode(data);
            Assert.Equal(mode.Count(), 1);
            Assert.True(mode.Contains(5));
        }

        [Fact]
        public void Mode_GivenAnArrayOfFloatsWithASingleMode_ReturnsAListWithASingleElement()
        {
            float[] data = new float[] { 1.1f, 2.2f, 3.3f, 4.4f, 5.5f, 5.5f, 6.6f, 7.7f };
            var mode = Mode(data);
            Assert.Equal(mode.Count(), 1);
            Assert.True(mode.Contains(5.5f));
        }

        [Fact]
        public void Mode_GivenAnArrayOfDoublesWithASingleMode_ReturnsAListWithASingleElement()
        {
            double[] data = new double[] { 1.1, 2.2, 3.3, 4.4, 5.5, 5.5, 6.6, 7.7 };
            var mode = Mode(data);
            Assert.Equal(mode.Count(), 1);
            Assert.True(mode.Contains(5.5));
        }


        [Fact]
        public void Mode_GivenAArrayOfIntsWithMultipleModes_ReturnsAListWithASingleElement()
        {
            int[] data = new int[] { 1, 2, 3, 4, 4, 5, 5, 6, 7 };
            var mode = Mode(data);
            Assert.Equal(mode.Count(), 2);
            Assert.True(mode.Contains(4));
            Assert.True(mode.Contains(5));
        }

        [Fact]
        public void Mode_GivenAArrayOfFloatsWithMultipleModes_ReturnsAListWithASingleElement()
        {
            float[] data = new float[] { 1.1f, 2.2f, 3.3f, 4.4f, 4.4f, 5.5f, 5.5f, 6.6f, 7.7f };
            var mode = Mode(data);
            Assert.Equal(mode.Count(), 2);
            Assert.True(mode.Contains(4.4f));
            Assert.True(mode.Contains(5.5f));
        }

        [Fact]
        public void Mode_GivenAArrayOfDoublesWithMultipleModes_ReturnsAListWithASingleElement()
        {
            double[] data = new double[] { 1.1, 2.2, 3.3, 4.4, 4.4, 5.5, 5.5, 6.6, 7.7 };
            var mode = Mode(data);
            Assert.Equal(mode.Count(), 2);
            Assert.True(mode.Contains(4.4));
            Assert.True(mode.Contains(5.5));
        }

        [Fact]
        public void Mode_GivenAListOfNumbersWithNoMode_ReturnsNull()
        {
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            var mode = Mode(data);
            Assert.Null(mode);
        }
    }

}

