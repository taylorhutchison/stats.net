using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using DataIO.Formats;

namespace DataIO.Read {

    public static class Reader {
        public static T OpenFile<T>(string resourcePath) where T: FormatReader, new() {
            T reader = new T();
            return OpenFile(resourcePath, reader);
        }
        public static T OpenFile<T>(string resourcePath, T reader) where T : FormatReader
        {
            if (File.Exists(resourcePath))
            {
                if (reader.CanRead(resourcePath))
                {
                    reader.Open(resourcePath);
                    return reader;
                }
            }
            throw new ArgumentException($"{resourcePath} does not exist.");
        }
    }
}