using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace DataIO.Formats
{
    public class CsvFormat : FormatReader
    {
        private const char DefaultDelimiter = ',';
        public char Delimiter { get; set; }

        private StreamReader streamReader;

        public IEnumerable<string> lines;

        private IDictionary<int, IEnumerable<string>> Columns = new Dictionary<int, IEnumerable<string>>();

        public override bool CanRead(string resourcePath)
        {
            FileInfo info = new FileInfo(resourcePath);
            if (info.Exists)
            {
                if (SupportedExtensions.Any(e => info.Extension.ToLower() == e.ToLower()))
                {
                    ResourcePath = resourcePath;
                    return true;
                }
            }
            return false;
        }

        protected virtual string[] ReadAll()
        {
            if (streamReader != null && Stream.CanRead)
            {
                Stream.Position = 0;
                var streamContents = streamReader.ReadToEnd();
                return streamContents.Split(new string[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);
            }
            return null;
        }

        public IEnumerable<string> GetHeader()
        {
            return lines.First().Split(Delimiter);
        }

        public IEnumerable<string> GetColumn(int columnNumber)
        {
            return GetColumn<string>(columnNumber);
        }

        public IEnumerable<T> GetColumn<T>(int columnNumber, T defaultValue)
        {
            return GetColumnWithDefault(columnNumber, defaultValue);
        }

        public IEnumerable<T> GetColumn<T>(int columnNumber)
        {
            return GetColumnWithoutDefault<T>(columnNumber);
        }

        private T Convert<T>(string str)
        {
            return (T)System.Convert.ChangeType(str, typeof(T));
        }

        private T Convert<T>(string str, T defaultValue)
        {
            try
            {
                return (T)System.Convert.ChangeType(str, typeof(T));
            }
            catch (InvalidCastException)
            {
                return defaultValue;
            }
            catch (FormatException)
            {
                return defaultValue;
            }
        }

        private IEnumerable<string> GetColumnFromLines(int columnNumber)
        {
            if (Columns.Keys.Contains(columnNumber))
            {
                return Columns[columnNumber];
            }

            var column = lines
                .Skip(1)
                .SelectMany(l =>
                {
                    return l.Split(Delimiter).Skip(columnNumber).Take(1);
                });

            Columns.Add(columnNumber, column);

            return column;
        }

        private IEnumerable<T> GetColumnWithoutDefault<T>(int columnNumber)
        {

            var column = GetColumnFromLines(columnNumber);

            return column.Select(s =>
                {
                    return Convert<T>(s);
                }
            );
        }

        private IEnumerable<T> GetColumnWithDefault<T>(int columnNumber, T defaultValue)
        {
            var column = GetColumnFromLines(columnNumber);
            return column.Select(s =>
                {
                    return Convert<T>(s, defaultValue);
                }
            );
        }

        protected override FormatReader Read(string resourcePath)
        {
            Stream = new FileStream(resourcePath, FileMode.Open, FileAccess.Read);
            var encoding = GetEncoding(Stream as FileStream);
            streamReader = new StreamReader(Stream as FileStream, encoding, true, 512);
            lines = ReadAll();
            return this;
        }

        private static Encoding GetEncoding(FileStream file)
        {
            var bom = new byte[4];
            file.Read(bom, 0, 4);
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf)
            {
                return Encoding.UTF8;
            }
            if (bom[0] == 0xff && bom[1] == 0xfe)
            {
                return Encoding.Unicode;
            }
            return Encoding.ASCII;
        }

        public override void Close()
        {

        }

        public CsvFormat()
        {
            SupportedExtensions = new string[] { ".csv" };
            Delimiter = DefaultDelimiter;
        }
    }
}
