using System.Diagnostics;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json; 

using BTD.Patcher.MapInfo;
using System;
using System.IO.Compression;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Resources.Extensions;
using Patcher;

namespace BTD.Patcher;

public struct PatchStrategyModel
{
    public IMapPatchingStrategy _type { get; set; }

    public string _file { get; set; }

    public string _requestedParameter { get; set; }
}

public class Patcher
{
    private List<PatchStrategyModel> _patchesInfo = new List<PatchStrategyModel>();

    private string _currentDirectory = String.Empty;

    public delegate void OnMapPatched();
    public event OnMapPatched ?MapPatched;

    public Patcher()
    {
        JObject mainObject = JObject.Parse(Configs.patcher_types);
        //JObject mainObject = JObject.Parse(File.ReadAllText(_patcherTypesConfigPath));
        foreach (JToken patcherObject in mainObject.Children())
        {
            foreach (JObject patchProperty in patcherObject.Children())
            {
                PatchStrategyModel newPatch = new PatchStrategyModel();
                newPatch._type = (IMapPatchingStrategy)Activator.CreateInstance(Type.GetType(patchProperty.GetValue("Type")!.ToString())!)!;
                newPatch._file = patchProperty.GetValue("File").ToString();
                newPatch._requestedParameter = patchProperty.GetValue("RequestedParameter").ToString();
                _patchesInfo.Add(newPatch);
            }
        }
    }

    private object? GetPatchParameter(object info, string param)
    {
        Type type = info.GetType();
        PropertyInfo propertyInfo = type.GetProperty(param)!;
        if(propertyInfo != null)
        {
            return propertyInfo.GetValue(info);
        }
        return null;
    }

    public void Run(MapBaseInfo mapInfo, MapFilesInfo mapFiles, MapPatchOptions patchOptions)
    {
        _currentDirectory = new FileInfo(mapFiles.mainXdb!).DirectoryName!;

        foreach (PatchStrategyModel patch in _patchesInfo)
        {
            string fileToPatch = GetPatchParameter(mapFiles, patch._file)!.ToString()!;
            string text = File.ReadAllText(fileToPatch);
            if(patch._requestedParameter != "")
            {
                patch._type.LoadAdditionalPatchSettings(GetPatchParameter(patchOptions, patch._requestedParameter));
            }
            patch._type._writer = WriteAdditionalFile;
            patch._type.Patch(ref text);
            File.WriteAllText(fileToPatch, text);
        }

        FileInfo _mapFileInfo = new FileInfo(mapInfo.name!);
        string _patchedMapDirectory = _mapFileInfo.DirectoryName!;
        string _patchedMapName = "BTD_" + _mapFileInfo.Name!;
        ZipFile.CreateFromDirectory(mapInfo.directory!, _patchedMapDirectory + "/" + _patchedMapName);

        MapPatched!();
    }

    private void WriteAdditionalFile(string name, string content)
    {
        File.WriteAllText(_currentDirectory + "/" + name, content);
    }
}