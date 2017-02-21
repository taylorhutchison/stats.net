using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataIO.Formats
{
    public abstract class FormatReader: IDisposable
    {
        public string ResourcePath { get; protected set; }
        public virtual Stream Stream { get; protected set; }
        public string[] SupportedExtensions { get; protected set; }
        public abstract bool CanRead(string resourcePath);
        protected abstract FormatReader Read(string resourcePath);
        public FormatReader Open(string resourcePath)
        {
            if (CanRead(resourcePath))
            {
                return Read(resourcePath);
            }
            throw new ArgumentException($"Cannot open file at {resourcePath}");
        }
        public virtual void Close()
        {
            Dispose();
        }

        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Stream.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
