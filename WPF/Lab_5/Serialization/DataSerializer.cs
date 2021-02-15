using Lab_5.Models;
using System.IO;
using System.Text.Json;

namespace Lab_5.Serialization
{
    public static class DataSerializer
    {
        public static void SerializeData(string fileName, DataModel data)
        {
            var serializedData = JsonSerializer.Serialize(data);
            File.WriteAllText(fileName, serializedData);
        }

        public static DataModel DeserializeItem(string fileName)
        {
            var dataJson = File.ReadAllText(fileName);

            var data = JsonSerializer.Deserialize<DataModel>(dataJson);

            return data;
        }
    }
}