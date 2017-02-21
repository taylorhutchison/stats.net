using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataIO.FormatReaders
{
    public class CsvFormat : FormatReader
    {
        public override bool CanRead(string resourceAddress)
        {
            if (SupportedExtensions.Any(e => resourceAddress.EndsWith(e)))
            {
                return true;
            }
            return false;
        }
        public CsvFormat()
        {
            SupportedExtensions = new string[] { "csv" };
        }
    }
}
