using Xunit;
using System;
using System.Linq;
using StatsNet.Tests.TestClasses;
using static StatsNet.Summary;

namespace StatsNet.Tests
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

        [Fact]
        public void Range_GivenAnArrayOfInts_ReturnsUpperAndLowerBounds(){
            int[] data = new int[] {9, 4, 3, 20, 1};
            var range = Range(data);
            Assert.Equal(2, range.Count());
            Assert.Equal(1, range.First());
            Assert.Equal(20, range.Last());
        }

        [Fact]
        public void Range_GivenAnArrayOfStrings_ReturnsUpperAndLowerBounds(){
            string[] data = new string[] {"absolute", "breakfast", "camp"};
            var range = Range(data);
            Assert.Equal(2, range.Count());
            Assert.Equal("absolute", range.First());
            Assert.Equal("camp", range.Last());
        }

        [Fact]
        public void Range_GivenAnEmptyArray_ReturnsUpperAndLowerBounds(){
            string[] data = new string[] {};
            var range = Range(data);
            Assert.Equal(2, range.Count());
            Assert.Equal(null, range.First());
            Assert.Equal(null, range.Last());
        }

        [Fact]
        public void Range_GivenAnNull_ReturnsUpperAndLowerBounds(){
            string[] data = null;
            var range = Range(data);
            Assert.Null(range);
        }

        [Fact]
        public void Range_GivenAnArrayOfPerson_ReturnsUpperAndLowerBounds(){
            Person[] data = new Person[] {
                new Person(30, "Taylor"),
                new Person(40, "Sara"),
                new Person(20, "Taylor")
            };
            var range = Range(data);
            Assert.Equal("Sara", range.First().Name);
            Assert.Equal("Taylor", range.Last().Name);
            Assert.Equal(30, range.Last().Age);
        }

        [Fact]
        public void StdDev_GivenAnArrayOfDoubles_ReturnsTheStandardDeviation()
        {
            double[] vector = new double[] { 9, 2, 5, 4, 12, 7, 8, 11, 9, 3, 7, 4, 12, 5, 4, 10, 9, 6, 9, 4 };
            var stdDev = StdDev(vector);
            Assert.Equal(2.983, stdDev, 3);
        }
    }

}

