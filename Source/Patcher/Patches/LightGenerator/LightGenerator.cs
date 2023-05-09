using Newtonsoft.Json;
using Patcher;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BTD.Patcher;

public class LightGenerator : IMapPatchingStrategy
{
    internal struct LightTypesModel
    {
        public List<string> _dayLights { get; set; }
        public List<string> _nightLights { get; set; }
    }

    private LightTypesModel _possibleLights = new LightTypesModel();

    private bool _useNightLight;

    public Action<string, string>? _writer { get; set; }
 
    public LightGenerator()
    {
        _possibleLights = JsonConvert.DeserializeObject<LightTypesModel>(Configs.lights);
    }

    public void LoadAdditionalPatchSettings(object? option)
    {
        _useNightLight = (bool)option!;
        Trace.WriteLine("Are we using night lights? - " + _useNightLight.ToString());
    }

    public void Patch(ref string text)
    {
        Random rand = new Random();
        List<string> currentLightsToUse = _useNightLight == true ? _possibleLights._nightLights : _possibleLights._dayLights;
        text = text.Replace("<AmbientLight/>", "<AmbientLight href=\"" + currentLightsToUse[rand.Next(currentLightsToUse.Count)] + "\"/>");
        string _lightsText = "\n";
        foreach(string _light in currentLightsToUse)
        {
            _lightsText = _lightsText + "\t\t<Item href=\"" + _light + "\"/>\n";
        }
        Regex _groundLightRegex = new Regex("<GroundAmbientLights.*?>(.*?)<\\/GroundAmbientLights>", RegexOptions.Singleline);
        string _groundLightString = _groundLightRegex.Match(text).Groups[1].ToString();
        text = text.Replace(_groundLightString, _lightsText);
    }
}