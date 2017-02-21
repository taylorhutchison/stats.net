using System;
using System.Collections.Generic;
using System.Text;

namespace DataIO.FormatReaders
{
    public abstract class FormatReader
    {
        public string[] SupportedExtensions { get; protected set; }
        public abstract bool CanRead(string resourceAddress);

    }
}
