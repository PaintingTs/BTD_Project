using System.Diagnostics;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json; 

using BTD.Patcher.MapInfo;
using Newtonsoft.Json.Linq;
using System;

namespace BTD.Patcher;

public class Patcher
{
    private readonly string _patcherTypesConfigPath = BTD.Path.Source + "Config/patcher_types.json";
    private List<IMapPatchingStrategy> _patchesTypes = new List<IMapPatchingStrategy>();

    public Patcher()
    {
        List<string> _patches = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(_patcherTypesConfigPath));
        foreach(string patch in _patches)
        {
            IMapPatchingStrategy _patchType = (IMapPatchingStrategy)Activator.CreateInstance(Type.GetType(patch)!)!;
            if(_patchType != null)
            {
                _patchesTypes.Add(_patchType);
            }
        }
    }

    public void Run(Map map)
    {
        Trace.WriteLine("Running patcher ");
        Trace.WriteLine("Map xdb - " + map.Xdb + ", template is " + map.Template);

        foreach(IMapPatchingStrategy patch in _patchesTypes)
        {
            patch.Patch(File.ReadAllText(map.Xdb!));
        }
    }
}