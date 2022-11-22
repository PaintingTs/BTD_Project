using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Diagnostics;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BTD.Patcher.MapInfo;
public class MapUnpacker
{
    private readonly string _detectorsInfoPath = BTD.Path.Source + "Config\\map_fields_decorators.json";
    private Dictionary<string, IMapInfoDetector> _detectorsInfo = new Dictionary<string, IMapInfoDetector>();
    private List<string> _alreadyDetectedFields = new List<string>();

    public delegate void OnMapUnpacked(Map map);
    public event OnMapUnpacked ?MapUnpacked;

    private string _tempDirectoryPath = String.Empty;

    public MapUnpacker()
    {
        JObject _mainObject = JObject.Parse(File.ReadAllText(_detectorsInfoPath));
        foreach(JProperty property in _mainObject.Children())
        {
            IMapInfoDetector _newDetector = (IMapInfoDetector)Activator.CreateInstance(Type.GetType(property.Value.ToString())!)!;
            if (_newDetector != null)
            {
                _detectorsInfo.Add(property.Name, _newDetector);
            }
        }
    }

    public void Unpack(string map_path)
    {
        _tempDirectoryPath = new FileInfo(map_path).Directory + "/_temp/";
        ZipFile.ExtractToDirectory(map_path, _tempDirectoryPath);
        SetupMapForPatch();
    }

    private void SetupMapForPatch()
    {
        Map _map = new Map();
        Type _mapType = typeof(Map);
        foreach(string file in Directory.GetFiles(_tempDirectoryPath, "*", SearchOption.AllDirectories))
        {
            foreach(KeyValuePair<string, IMapInfoDetector> _tempDetector in _detectorsInfo)
            {
                if (!_alreadyDetectedFields.Contains(_tempDetector.Key) && _tempDetector.Value.CanBeDetected(file))
                {
                    PropertyInfo _tempProperty = _mapType.GetProperty(_tempDetector.Key)!;
                    if(_tempProperty != null)
                    {
                        _tempProperty.SetValue(_map, _tempDetector.Value.DetectValue(file));
                        _alreadyDetectedFields.Add(_tempDetector.Key);
                    }
                }    
            }
        }
        MapUnpacked!(_map);
    }
}
