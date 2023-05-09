using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;

using System.Collections.Generic;

using BTD.Patcher;
using System.Collections.ObjectModel;

namespace BTD.Patcher.UI;

public class TeamBuilderFascade : IMapOptionsModifier
{
    private int _playersCount;
    public int playersCount
    {
        get { return _playersCount; }
    }

    private Dictionary<int, int> _playerTeamInfo = new Dictionary<int, int>();

    public delegate void OnTeamsCountChanged(int new_count);
    public event OnTeamsCountChanged ?TeamsCountChanged;

    public event IMapOptionsModifier.OnMapOptionChanged? MapOptionChanged;

    public void Init(int players)
    {
        _playersCount = players;
    }

    public void TeamsCountComboBoxSelectionChanged(object sender, RoutedEventArgs e)
    {
        int item = Convert.ToInt32(((sender as ComboBox)!.SelectedItem));
        TeamsCountChanged!(item);
    }

    public void UpdatePlayersTeamInfo(int player, int team)
    {
        _playerTeamInfo[player] = team;
    }

    public void SaveTeamInfoButtonClicked(object sender, RoutedEventArgs e)
    {
        MapOptionChanged!("playersTeamInfo", _playerTeamInfo);
    }
}