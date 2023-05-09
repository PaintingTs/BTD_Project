using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BTD.Patcher;

public class TeamGenerator : IMapPatchingStrategy
{
    private Dictionary<int, int> _playersTeamInfo = new Dictionary<int, int>();
    private Dictionary<int, int> _teamPlayersCountInfo = new Dictionary<int, int>();
    public Action<string, string>? _writer { get; set; }

    public void LoadAdditionalPatchSettings(object? option)
    {
        _playersTeamInfo = (option as Dictionary<int, int>)!;
    }

    public void Patch(ref string text)
    {
        if (_playersTeamInfo.Keys.Count == 0)
        {
            return;
        }
        foreach(KeyValuePair<int, int> kvp in _playersTeamInfo)
        {
            if(_teamPlayersCountInfo.ContainsKey(kvp.Value) == false)
            {
                _teamPlayersCountInfo.Add(kvp.Value, 1);
            }
            else
            {
                _teamPlayersCountInfo[kvp.Value]++;
            }    
        }

        string generatedTeamsString = "\n";
        foreach(KeyValuePair<int, int> kvp in _teamPlayersCountInfo)
        {
            generatedTeamsString = generatedTeamsString + "\t\t<Item>" + kvp.Value.ToString() + "</Item>\n";
        }

        Regex teamsRegex = new Regex("<teams.*?>([^|]*)<\\/teams>", RegexOptions.Singleline);
        string teamsString = teamsRegex.Match(text).Groups[1].ToString();
        text = text.Replace(teamsString, generatedTeamsString);
    }
}

public class TeamInfoModifier : IMapPatchingStrategy
{
    private Dictionary<int, int> _playersTeamInfo = new Dictionary<int, int>();
    public Action<string, string>? _writer { get; set; }

    public void LoadAdditionalPatchSettings(object? option)
    {
        _playersTeamInfo = (option as Dictionary<int, int>)!;
    }

    public void Patch(ref string text)
    {
        if (_playersTeamInfo.Keys.Count == 0)
        {
            return;
        }
        text = text.Replace("<CustomTeams>false</CustomTeams>", "<CustomTeams>true</CustomTeams>");

        Regex playersRegex = new Regex("<players.*?>([^|]*)<\\/players>", RegexOptions.Singleline);
        string playersString = playersRegex.Match(text).Groups[1].ToString();
        Regex itemRegex = new Regex("<Item.*?>(.*?)<\\/Item>", RegexOptions.Singleline);
        int num = 0;
        string newPlayersString = "\t\t\n";
        foreach(Match itemMatch in itemRegex.Matches(playersString))
        {
            num++;
            if(itemMatch.Success == true)
            {
                string itemString = itemMatch.Groups[0].ToString();
                if(_playersTeamInfo.ContainsKey(num) == true)
                {
                    string newTeamString = "<Team>" + (_playersTeamInfo[num] - 1).ToString() + "</Team>";
                    string updatedItemString = itemString.Replace("<Team>0</Team>", newTeamString);
                    newPlayersString += (updatedItemString + "\n");
                }
                else
                {
                    newPlayersString += (itemString + "\n");
                }
            }
        }
        text = text.Replace(playersString, newPlayersString);
    }
}
