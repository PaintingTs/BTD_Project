using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Diagnostics;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace BTD.Patcher;

public struct DetectorDecoratorProps
{
    public string _config { get; set; }
    public string _output { get; set; }
}

internal struct MapObjectDefinition
{
    public string _type { get; set; }
    public string _shared { get; set; }
}

public class ObjectDetector : IMapPatchingStrategy
{
    internal struct DetectorDecoratorInfo
    {
        public string _type { get; set; }
        public string _name { get; set; }
        public DetectorDecoratorProps _props { get; set; }
    }
    private readonly string _decoratorsConfigPath = BTD.Path.Source + "Patcher/Patches/ObjectDetector/Decorators/Config/decorators_types.json";
    private readonly string _possibleObjectsNamesPath = BTD.Path.Source + "Patcher/Patches/ObjectDetector/Decorators/Config/objects_names.json";

    private List<string> _possibleObjectsNames = new List<string>();
    private Dictionary<IObjectRecognizingStrategy, string> _possibleDecorators = new Dictionary<IObjectRecognizingStrategy, string>();
    private Dictionary<string, int> _objectsCounts = new Dictionary<string, int>();

    public ObjectDetector()
    {
        JObject _decoratorsInfoObject = JObject.Parse(File.ReadAllText(_decoratorsConfigPath));
        foreach(JProperty _property in _decoratorsInfoObject.Properties())
        {
            DetectorDecoratorInfo _decoratorInfo = JsonConvert.DeserializeObject<DetectorDecoratorInfo>(_property.Value.ToString());
            IObjectRecognizingStrategy _newDetector = (IObjectRecognizingStrategy)Activator.CreateInstance(Type.GetType(_decoratorInfo._type)!)!;
            if(_newDetector != null)
            {
                _newDetector.Init(_decoratorInfo._props);
                _newDetector._numerator = NumerateObject;
                _possibleDecorators.Add(_newDetector, _decoratorInfo._name);
            }
        }
        _possibleObjectsNames = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(_possibleObjectsNamesPath));
    }

    public void Patch(ref string text)
    {
        Regex _objectsRegex = new Regex("<objects.*?>([^|]*)<\\/objects>", RegexOptions.Singleline);
        Regex _itemRegex = new Regex("<Item.*?>(.*?)<\\/Item>", RegexOptions.Singleline);

        string _allObjects = _objectsRegex.Match(text).Groups[1].ToString();
        string _newObjects = _allObjects;
        foreach (Match _objectInfo in _itemRegex.Matches(_allObjects))
        {
            string _object = _objectInfo.Value;
            string _name = DetectName(_object);
            IEnumerable<IObjectRecognizingStrategy> _currentDecorators = from KeyValuePair<IObjectRecognizingStrategy, string> kvp in _possibleDecorators
                                                                         where kvp.Value == _name
                                                                         select kvp.Key;
            if(_currentDecorators.Any())
            {
                foreach(IObjectRecognizingStrategy _currentDecorator in _currentDecorators)
                {
                    string _newObject = _currentDecorator.AnalyzeObject(_object)!;
                    if(_newObject != null)
                    {
                        _newObjects = _newObjects.Replace(_object, _newObject);
                    }
                }
            }
        }
        text = text.Replace(_allObjects, _newObjects);
        string _luaOutput = String.Empty;
        foreach (KeyValuePair<IObjectRecognizingStrategy, string> kvp in _possibleDecorators)
        {
            _luaOutput += kvp.Key.GetScript();
        }
        File.WriteAllText(BTD.Path.Main + "test.lua", _luaOutput);
    }

    private string DetectName(string object_info)
    {
        foreach(string _name in _possibleObjectsNames)
        {
            if(object_info.Contains(_name))
            {
                return _name;
            }
        }
        return String.Empty;
    }

    private int NumerateObject(string type)
    {
        if (!_objectsCounts.ContainsKey(type))
        {
            _objectsCounts.Add(type, 0);
        }
        _objectsCounts[type]++;
        return _objectsCounts[type];
    }
}