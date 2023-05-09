using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTD.Patcher;
public class TreasureDetector : IObjectRecognizingStrategy
{
    public Func<string, int>? _numerator { get; set; }
    private string _outputScript = String.Empty;

    public string? AnalyzeObject(string object_info)
    {
        int _currentNumber = _numerator!("Treasure");
        string _name = "Treasure" + "_" + _currentNumber;
        _outputScript = _outputScript + "\t\"" + _name + "\",\n";
        return object_info.Replace("<Name/>", "<Name>" + _name + "</Name>");
    }

    public string? GetScript()
    {
        return _outputScript + "}\n\n";
    }

    public void Init(DetectorDecoratorProps props)
    {
        _outputScript = "TREASURES = \n{\n";
    }
}
