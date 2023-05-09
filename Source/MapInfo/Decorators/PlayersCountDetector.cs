using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace BTD.Patcher.MapInfo;

public class PlayersCountDetector : IMapInfoDetector
{
    public bool CanBeDetected(string path)
    {
        return path.Contains("RMG") && path.EndsWith("map-tag.xdb");
    }

    public string? DetectValue(string path)
    {
        Regex teamsRegex = new Regex("<teams.*?>([^|]*)<\\/teams>", RegexOptions.Singleline);
        Regex itemRegex = new Regex("<Item>" + "(.*)" + "</Item>");
        string teamsString = teamsRegex.Match(File.ReadAllText(path)).Groups[1].ToString();
        int teamsCount = itemRegex.Matches(teamsString).Count;
        return teamsCount.ToString();
    }
}
