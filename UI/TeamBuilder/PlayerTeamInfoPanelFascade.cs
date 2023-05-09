using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BTD.Patcher.UI;
public class PlayerTeamInfoPanelFascade
{
    private int _player;
    public int player { get { return _player; } }

    public delegate void OnPlayerTeamChanged(int player, int team);
    public event OnPlayerTeamChanged ?PlayerTeamChanged;
    public void Init(int player_num)
    {
        _player = player_num;
    }
    public void TeamSelectorComboBox_SelectionChanged(object sender, RoutedEventArgs e)
    {
        int team = (int)(sender as ComboBox)!.SelectedItem;
        PlayerTeamChanged!(_player, team);
    }
}
