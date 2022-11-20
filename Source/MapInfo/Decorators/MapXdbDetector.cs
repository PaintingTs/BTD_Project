using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTD.Patcher.MapInfo;

public class XdbDetector : IMapInfoDetector
{
    public bool CanBeDetected(string path)
    {
        return path.Contains("RMG") && path.EndsWith("map.xdb");
    }

    public string? DetectValue(string path)
    {
        return path;
    }
}
