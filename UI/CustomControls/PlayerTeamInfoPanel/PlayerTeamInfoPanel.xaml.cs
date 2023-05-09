using BTD.Patcher.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Patcher.UI.CustomControls.PlayerTeamInfoPanel
{
    /// <summary>
    /// Логика взаимодействия для PlayerTeamInfoPanel.xaml
    /// </summary>
    public partial class PlayerTeamInfoPanel : UserControl
    {
        private PlayerTeamInfoPanelFascade ?_playerTeamInfoPanelFascade;
        public PlayerTeamInfoPanel()
        {
            InitializeComponent();
        }

        public void Init(PlayerTeamInfoPanelFascade fascade)
        {
            _playerTeamInfoPanelFascade = fascade;
            PlayerInfoLabel.Content = "Игрок " + fascade.player.ToString();

            TeamSelectorComboBox.SelectionChanged += fascade.TeamSelectorComboBox_SelectionChanged;
        }

        public void ChangeTeamsList(int teams_count)
        {
            ObservableCollection<int> teamsList = new ObservableCollection<int>();
            for(int i = 1; i <= teams_count; i++)
            {
                teamsList.Add(i);
            }
            TeamSelectorComboBox.ItemsSource = teamsList;
            if (TeamSelectorComboBox.IsEnabled == false)
            {
                TeamSelectorComboBox.IsEnabled = true;
            }
        }
    }
}
