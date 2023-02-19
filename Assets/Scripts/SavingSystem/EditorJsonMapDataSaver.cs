using LevelMap;
using Newtonsoft.Json;
using System.IO;
using UnityEngine;

namespace SaveSystem
{
    public class EditorJsonMapDataSaver : IMapDataSaver
    {
        private readonly string BaseMapSavePath = "BaseMap";

        public Map LoadMap()
        {
            TextAsset targetFile = UnityEngine.Resources.Load<TextAsset>(BaseMapSavePath);

            if (targetFile == null)
            {
                return new Map();
            }

            var map = JsonConvert.DeserializeObject<Map>(targetFile.text);
            return map;
        }

        public void SaveMap(Map map)
        {
            var serializedMap = JsonConvert.SerializeObject(map);
            
            File.WriteAllText(BaseMapSavePath, serializedMap);
        }
    }
}
