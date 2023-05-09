using Patcher;
using System;
using System.IO;

namespace BTD.Patcher;

public class ScriptGenerator : IMapPatchingStrategy
{
    public Action<string, string>? _writer { get; set; }

    public void LoadAdditionalPatchSettings(object? value)
    { }

    public void Patch(ref string text)
    {
        text = text.Replace("<MapScript/>", "<MapScript href=\"MapScript.xdb#xpointer(/Script)\"/>");
        text = text.Replace("<RMGmap>true</RMGmap>", "<RMGmap>false</RMGmap>");
        _writer!("MapScript.lua", "--");
        _writer!("MapScript.xdb", Configs.script_xdb);
    }
}
