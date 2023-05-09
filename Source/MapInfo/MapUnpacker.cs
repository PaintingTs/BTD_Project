using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;

using Newtonsoft.Json.Linq;
using Patcher;

namespace BTD.Patcher.MapInfo;
public class MapUnpacker
{
    private Dictionary<string, IMapInfoDetector> _baseDetectors = new Dictionary<string, IMapInfoDetector>();
    private Dictionary<string, IMapInfoDetector> _fileDetectors = new Dictionary<string, IMapInfoDetector>();

    public delegate void OnMapUnpacked(MapBaseInfo baseInfo, MapFilesInfo filesInfo);
    public event OnMapUnpacked ?MapUnpacked;

    private string _tempDirectoryPath = String.Empty;

    public MapUnpacker()
    {
        JObject mainObject = JObject.Parse(Configs.map_fields_detectors);
        JToken baseDetectorsToken = mainObject.GetValue("BaseDetectors");
        foreach(JProperty property in baseDetectorsToken.Children())
        {
            IMapInfoDetector newDetector = (IMapInfoDetector)Activator.CreateInstance(Type.GetType(property.Value.ToString())!)!;
            if (newDetector != null)
            {
                _baseDetectors.Add(property.Name, newDetector);
            }
        }
        //
        JToken fileDetectorsToken = mainObject.GetValue("FileDetectors");
        foreach (JProperty property in fileDetectorsToken.Children())
        {
            IMapInfoDetector newDetector = (IMapInfoDetector)Activator.CreateInstance(Type.GetType(property.Value.ToString())!)!;
            if (newDetector != null)
            {
                _fileDetectors.Add(property.Name, newDetector);
            }
        }
    }

    public void Unpack(string map_path)
    {
        MapBaseInfo baseInfo = new MapBaseInfo();
        MapFilesInfo filesInfo = new MapFilesInfo();
        baseInfo.name = map_path;
        _tempDirectoryPath = new FileInfo(map_path).Directory + "/_temp/";
        baseInfo.directory = _tempDirectoryPath;
        Clean();
        ZipFile.ExtractToDirectory(map_path, _tempDirectoryPath);

        //baseInfo = (MapBaseInfo)CollectMapInfo(baseInfo, _baseDetectors);
        //filesInfo = (MapFilesInfo)CollectMapInfo(filesInfo, _fileDetectors);

        CollectMapInfo(baseInfo, _baseDetectors);
        CollectMapInfo(filesInfo, _fileDetectors);

        MapUnpacked!(baseInfo, filesInfo);
    }

    private object CollectMapInfo(object info, Dictionary<string, IMapInfoDetector> detectors)
    {
        List<string> _alreadyDetectedFields = new List<string>();
        Type infoType = info.GetType();
        foreach (string file in Directory.GetFiles(_tempDirectoryPath, "*", SearchOption.AllDirectories))
        {
            foreach (KeyValuePair<string, IMapInfoDetector> tempDetector in detectors)
            {
                if (!_alreadyDetectedFields.Contains(tempDetector.Key) && tempDetector.Value.CanBeDetected(file))
                {
                    PropertyInfo _tempProperty = infoType.GetProperty(tempDetector.Key)!;
                    if (_tempProperty != null)
                    {
                        string detectedValue = tempDetector.Value.DetectValue(file)!;
                        _tempProperty.SetValue(info, detectedValue);
                        _alreadyDetectedFields.Add(tempDetector.Key);
                    }
                }
            }
        }
        return info;
    }

    public void Clean()
    {
        if (Directory.Exists(_tempDirectoryPath))
        {
            Directory.Delete(_tempDirectoryPath, true);
        }
    }
}