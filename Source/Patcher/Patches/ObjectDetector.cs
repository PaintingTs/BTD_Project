using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Diagnostics;

using Newtonsoft.Json;

namespace BTD.Patcher;

public class ObjectDetector : IMapPatchingStrategy
{
    internal struct MapObjectDefinition
    {
        public string _type { get; set; }
        public string _shared { get; set; }
    }

    private readonly string _mapObjectsConfigPath = BTD.Path.Source + "Config/object_type_mapping.json";
    private List<MapObjectDefinition> _mapObjectTypes = new List<MapObjectDefinition>();

    private Dictionary<string, int> _objectsCounts = new Dictionary<string, int>();
    private Dictionary<string, string> _objectsOutputMap = new Dictionary<string, string>();

    public ObjectDetector()
    {
        _mapObjectTypes = JsonConvert.DeserializeObject<List<MapObjectDefinition>>(File.ReadAllText(_mapObjectsConfigPath));
    }

    public void Patch(string text)
    {
        Regex _objectsRegex = new Regex("<objects.*?>([^|]*)<\\/objects>", RegexOptions.Singleline);
        Regex _buildingRegex = new Regex("<Item.*?>(.*?)<\\/Item>", RegexOptions.Singleline);
        Regex _sharedRegex = new Regex("<Shared href=\"" + "(.*)" + "#");
        Regex _nameRegex = new Regex("<Name(.*)>");
        string _allObjects = _objectsRegex.Match(text).Groups[1].ToString();
        string _newObjects = _allObjects;
        foreach (Match building_info in _buildingRegex.Matches(_allObjects))
        {
            string _building = building_info.Value;
            string _shared = _sharedRegex.Match(_building).Groups[1].ToString();
            IEnumerable<string> _types = from MapObjectDefinition obj in _mapObjectTypes
                                         where obj._shared == _shared
                                         select obj._type;
            if (_types.Any())
            {
                if (_types.First() != null)
                {
                    if (!_objectsCounts.ContainsKey(_types.First()))
                    {
                        _objectsCounts.Add(_types.First(), 0);
                    }
                    _objectsCounts[_types.First()]++;
                    string _name = _types.First() + "_" + _objectsCounts[_types.First()].ToString();
                    _objectsOutputMap.Add(_name, _types.First());
                    string _newBuilding = _building.Replace("<Name/>", "<Name>" + _name + "</Name>");
                    _newObjects = _newObjects.Replace(_building, _newBuilding);
                }
            }
        }
        text = text.Replace(_allObjects, _newObjects);
        string _luaOutput = "BTD_NewObjects = \n{\n";
        foreach(KeyValuePair<string, string> _objectInfo in _objectsOutputMap)
        {
            _luaOutput = _luaOutput + "\t[\"" + _objectInfo.Key + "\"] = " + _objectInfo.Value + ",\n";
        }
        _luaOutput += "}";
        File.WriteAllText(BTD.Path.Main + "test.lua", _luaOutput);
    }
}
