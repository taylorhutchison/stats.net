using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace DataIO.Formats
{
    public class CsvFormat : FormatReader
    {
        private StreamReader streamReader;
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

        public IEnumerable<string> GetHeader()
        {
            if (streamReader != null && Stream.CanRead)
            {
                Stream.Position = 0;
                var line = streamReader.ReadLine();
                return line.Split(',');
            }
            return null;
        }

        protected override FormatReader Read(string resourcePath)
        {
            Stream = new FileStream(resourcePath, FileMode.Open, FileAccess.Read);
            streamReader = new StreamReader(Stream as FileStream, Encoding.UTF8, true, 512);
            return this;
        }

        public override void Close()
        {

        }

        public CsvFormat()
        {
            SupportedExtensions = new string[] { ".csv" };
        }
    }
}
