using LevelMap;
using Newtonsoft.Json;
using System.IO;
using UnityEngine;

namespace SaveSystem
{
    public class JsonMapDataSaver : IMapDataSaver
    {
        private const string BaseCellsMapSavePath = @"BaseMaps\BaseCellsMap";
        private const string BaseBuildigMapSavePath = @"BaseMaps\BaseBuildigsMap";

        private string BuildingsMapSavePath => Application.persistentDataPath + @"\BuildingsMap.json";

        public CellsMap LoadBaseCellsMap()
        {
            TextAsset targetFile = UnityEngine.Resources.Load<TextAsset>(BaseCellsMapSavePath);

            if (targetFile == null)
            {
                return new CellsMap();
            }

            var map = JsonConvert.DeserializeObject<CellsMap>(targetFile.text);
            return map;
        }

        public void SaveBuildingsMap(BuildingsMap buildingsMap)
        {
            if (!File.Exists(BuildingsMapSavePath))
            {
                File.Create(BuildingsMapSavePath);
            }

            var map = JsonConvert.SerializeObject(buildingsMap);
            File.WriteAllText(BuildingsMapSavePath, map);
        }

        public BuildingsMap LoadBaseBuildingsMap()
        {
            TextAsset targetFile = UnityEngine.Resources.Load<TextAsset>(BaseBuildigMapSavePath);

            if (targetFile == null)
            {
                return new BuildingsMap();
            }

            var map = JsonConvert.DeserializeObject<BuildingsMap>(targetFile.text);
            return map;
        }

        public BuildingsMap LoadCurrentBuildingsMap()
        {
            if (!File.Exists(BuildingsMapSavePath))
            {
                return LoadBaseBuildingsMap();
            }

            var file = File.ReadAllText(BuildingsMapSavePath);
            var map = JsonConvert.DeserializeObject<BuildingsMap>(file);
            return map;
        }
    }
}
