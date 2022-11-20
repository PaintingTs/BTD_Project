using System.IO;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace BTD.Patcher.MapInfo;

public class TemplateDetector : IMapInfoDetector
{
    private string _templatesInfoPath = BTD.Path.Source + "Config\\templates.json";
    private List<string> _possibleTemplates = new List<string>();

    public TemplateDetector()
    {
        _possibleTemplates = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(_templatesInfoPath))!;
    }

    public bool CanBeDetected(string path)
    {
        return path.Contains("mapdesc-text-0");
    }

    public string? DetectValue(string path)
    {
        string _text = File.ReadAllText(path);
        foreach (string template in _possibleTemplates)
        {
            if(_text.Contains(template))
            {
                return template;
            }
        }
        return null;
    }
}
