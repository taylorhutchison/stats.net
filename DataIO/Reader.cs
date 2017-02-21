using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using DataIO.FormatReaders;

namespace DataIO.Read {

    public static class Reader {
        
        public static T Read<T>(string resourcePath) where T: FormatReader, new() {
            if(File.Exists(resourcePath)){
                T reader = new T();
                if (reader.CanRead(resourcePath))
                {
                    return reader;
                }
            }
            throw new ArgumentException($"{resourcePath} does not exist.");
        }
        public static T Read<T>(string resourcePath, T reader) where T : FormatReader
        {
            if (File.Exists(resourcePath))
            {
                if (reader.CanRead(resourcePath))
                {
                    return reader;
                }
            }
            throw new ArgumentException($"{resourcePath} does not exist.");
        }
    }
}