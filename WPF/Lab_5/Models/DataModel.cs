using Lab_5.Enums;
using Lab_5.Serialization;
using System;
using System.Collections.Generic;
using System.IO;

namespace Lab_5.Models
{
    [Serializable]
    public class DataModel
    {
        private static string _filePath = @"../../Data/data.json";

        public IEnumerable<NinjaModel> Ninjas { get; set; }

        public IEnumerable<NinjaType> NinjaTypes { get; set; }

        public static DataModel Load()
        {
            return File.Exists(_filePath) ? DataSerializer.DeserializeItem(_filePath) : new DataModel();
        }

        public void Save()
        {
            DataSerializer.SerializeData(_filePath, this);
        }
    }
}