using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTD.Patcher.MapInfo;

public class MainXdbDetector : IMapInfoDetector
{
    public bool CanBeDetected(string path)
    {
        return path.EndsWith("map.xdb");
    }

    public string? DetectValue(string path)
    {
        return path;
    }
}

public class MapTagDetector : IMapInfoDetector
{
    public bool CanBeDetected(string path)
    {
        return path.EndsWith("map-tag.xdb");
    }

    public string? DetectValue(string path)
    {
        return path;
    }
}