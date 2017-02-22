using System;
using DataIO.Read;
using DataIO.Formats;
using StatsNet;
using System.IO;
using System.Linq;

namespace CSVProcessor
{
    class Program
    {
        static void Main()
        {
            try
            {
                var reader = Reader.OpenFile<CsvFormat>(@"..\..\..\tests\data\csvsample1.csv");
                var header = reader.GetHeader();
                foreach (var item in header)
                {
                    Console.WriteLine(item);
                }

                var col4 = reader.GetColumn<int>(3);
                col4.ToList().ForEach(Console.WriteLine);

                var range = Summary.Range(col4);

                Console.WriteLine($"Range: {range.First()} - {range.Last()}");

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();

        }
    }
}