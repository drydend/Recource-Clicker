using LevelMap;
using Newtonsoft.Json;
using System.IO;
using UnityEngine;

namespace SaveSystem
{
    public class EditorJsonMapDataSaver : IMapDataSaver
    {
        private readonly string MapSavePath = Application.dataPath + "/Saving/Map.json";

        public Map LoadMap()
        {
            if (!File.Exists(MapSavePath))
            {
                return new Map();
            }

            var serializedData = File.ReadAllText(MapSavePath);
            var map = JsonConvert.DeserializeObject<Map>(serializedData);
            return map;
        }

        public void SaveMap(Map map)
        {
            var serializedMap = JsonConvert.SerializeObject(map);
            
            File.WriteAllText(MapSavePath, serializedMap);
        }
    }
}
