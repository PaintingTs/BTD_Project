using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BTD.Patcher;

public class BuildingDetector : IObjectRecognizingStrategy
{
    private List<MapObjectDefinition> _objectsTypes = new List<MapObjectDefinition>();
    private string _outputScript = String.Empty;
    public Func<string, int>? _numerator { get; set; }

    public string? AnalyzeObject(string object_info)
    {
        string _shared = IObjectRecognizingStrategy._sharedRegex.Match(object_info).Groups[1].ToString();
        IEnumerable<string> _types = from MapObjectDefinition obj in _objectsTypes
                                     where obj._shared == _shared
                                     select obj._type;
        if (_types.Any())
        {
            string _type = _types.First();
            int _currentNumber = _numerator!(_type);
            string _name = _type + "_" + _currentNumber;
            _outputScript = _outputScript + "\t[\"" + _name + "\"] = " + _type + ",\n"; 
            return object_info.Replace("<Name/>", "<Name>" + _name + "</Name>");
        }
        return null;
    }

    public string? GetScript()
    {
        return _outputScript + "}\n\n";
    }

    void IObjectRecognizingStrategy.Init(DetectorDecoratorProps props)
    {
        _objectsTypes = JsonConvert.DeserializeObject<List<MapObjectDefinition>>(File.ReadAllText(BTD.Path.Source + "Patcher/Patches/ObjectDetector/Decorators/Config/" + props._config));
        _outputScript = props._output + " =\n{\n";
    }
}