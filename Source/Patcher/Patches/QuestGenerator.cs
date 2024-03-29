﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Patcher;

namespace BTD.Patcher;

public class QuestGenerator : IMapPatchingStrategy
{
    Action<string, string>? IMapPatchingStrategy._writer { get; set; }

    public void LoadAdditionalPatchSettings(object? value)
    { }

    public void Patch(ref string text)
    {
        Regex _secondaryRegex = new Regex("<Secondary.*?>(.*?)<\\/Secondary>", RegexOptions.Singleline);
        Regex _commonRegex = new Regex("<Common.*?>(.*?)<\\/Common>", RegexOptions.Singleline);
        Regex _objectivesRegex = new Regex("<Objectives.*?>(.*?)<\\/Objectives>", RegexOptions.Singleline);
        Match _secondaryMatch = _secondaryRegex.Match(text);
        if (_secondaryMatch.Success)
        {
            string _secondaryString = _secondaryMatch.Groups[1].ToString();
            string _newSecondaryString = _secondaryString;
            Match common_match = _commonRegex.Match(_secondaryString);
            if (common_match.Success)
            {
                string _commonString = common_match.Groups[1].ToString();
                string _newCommonString = _commonString;
                Match _objectivesMatch = _objectivesRegex.Match(_commonString);
                if (_objectivesMatch.Success)
                {
                    string _objectivesString = _objectivesMatch.Groups[1].ToString();
                    _newCommonString = _newCommonString.Replace(_objectivesString, _objectivesString + Configs.Quest);
                }
                else
                {
                    _newCommonString = _newCommonString.Replace("<Objectives/>", "<Objectives>\n" + Configs.Quest + "</Objectives>");
                }
                _newSecondaryString = _newSecondaryString.Replace(_commonString, _newCommonString);
            }
            text = text.Replace(_secondaryString, _newSecondaryString);
        }
    }
}
