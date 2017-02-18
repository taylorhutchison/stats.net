using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace DataIO.Net {


    public static class Reader {

        public static IList<Format> Formats { get; private set; }
        public static void ClearFormats(){
            Formats = new List<Format>();
        }
        public static void AddFormat(Format format){
            Formats.Add(format);
        }

        public static void RegisterFormats(params Format[] formats){
            foreach(var format in formats){
                AddFormat(format);
            }
        }

        static Reader(){
            Formats = new List<Format>();
        }
        
        public static StreamReader Read(string resourcePath){
            if(File.Exists(resourcePath)){
                return new StreamReader(new MemoryStream());
            }
            throw new ArgumentException($"{resourcePath} does not exist.");
        }
    }

    public abstract class Format {
        public string[] SupportedExtensions {get; protected set;}
        public abstract bool CanRead(string resourceAddress);

    }

    public class CsvFormat : Format {
        public override bool CanRead(string resourceAddress){
            if(SupportedExtensions.Any(e => resourceAddress.EndsWith(e))){
                return true;
            }
            return false;
        }
        public CsvFormat(){
            SupportedExtensions = new string[]{"csv"};
        }
    }
}