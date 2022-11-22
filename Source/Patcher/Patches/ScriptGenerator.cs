using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BTD.Patcher;

public class ScriptGenerator : IMapPatchingStrategy
{
    public void Patch(string text)
    {
        Regex _scriptRegex = new Regex("<MapScript(.*)>");
        Match _scriptMatch = _scriptRegex.Match(text);
    }
}
