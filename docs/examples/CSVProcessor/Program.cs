using System;
using DataIO.Read;
using DataIO.Formats;
using StatsNet;
using System.IO;

namespace CSVProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var reader = Reader.OpenFile<CsvFormat>(@"C:\Users\Taylor Hutchison\Source\Repos\stats.net\tests\data\csvsample1.csv");

                var header = reader.GetHeader();
                foreach (var item in header)
                {
                    Console.WriteLine(item);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

        }
    }
}