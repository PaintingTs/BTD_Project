using System;
using System.Windows;
using System.Windows.Controls;

using System.Diagnostics;

using Patcher.UI.CustomControls.PlayerTeamInfoPanel;
using System.Collections.ObjectModel;
using BTD.Patcher.UI;

namespace Patcher
{
    /// <summary>
    /// Логика взаимодействия для TeamBuilderWindow.xaml
    /// </summary>
    public partial class TeamBuilderWindow : Window
    {
        private TeamBuilderFascade ?_teamBuilderFascade;

        public TeamBuilderWindow()
        {
            InitializeComponent();
        }

        public void Init(TeamBuilderFascade fascade)
        {
            _teamBuilderFascade = fascade;
            CreatePossibleTeamsList(fascade.playersCount);
            CreatePlayersPanels(fascade.playersCount);
            //
            PlayerNumLabel.Content = "Число игроков: " + fascade.playersCount.ToString();
            //
            TeamCountComboBox.SelectionChanged += _teamBuilderFascade!.TeamsCountComboBoxSelectionChanged;
            BuildTeamsButton.Click += _teamBuilderFascade.SaveTeamInfoButtonClicked;
            BuildTeamsButton.Click += (o, e) => MessageBox.Show("Команды успешно сгенерированы!");
        }
        
        private void CreatePossibleTeamsList(int count)
        {
            ObservableCollection<int> possibleTeams = new ObservableCollection<int>();
            for (int i = 2; i <= count; i++)
            {
                possibleTeams.Add(i);
            }
            TeamCountComboBox.ItemsSource = possibleTeams;
        }

        private void CreatePlayersPanels(int teams_count)
        {
            int row_num = (int)Math.Ceiling(teams_count / 2.0);
            Trace.WriteLine("Row number: " + row_num.ToString());
            for (int i = 0; i < row_num; i++)
            {
                RowDefinition row = new RowDefinition();
                TeamsInfoGrid.RowDefinitions.Add(row);
            }
            for(int i = 0; i < 2; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                TeamsInfoGrid.ColumnDefinitions.Add(col);
            }
            for (int player = 1; player <= teams_count; player++)
            {
                PlayerTeamInfoPanel tp = new PlayerTeamInfoPanel();
                PlayerTeamInfoPanelFascade fascade = new PlayerTeamInfoPanelFascade();
                fascade.Init(player);
                tp.Init(fascade);
                _teamBuilderFascade!.TeamsCountChanged += tp.ChangeTeamsList;
                fascade.PlayerTeamChanged += _teamBuilderFascade.UpdatePlayersTeamInfo;
                int cn = player % 2 == 0 ? 1 : 0;
                int rn = (int)Math.Floor((player - 1) / 2.0);
                //Trace.WriteLine("Player " + player.ToString() + ", column - " + cn.ToString() + " row - " + rn.ToString());
                Grid.SetRow(tp, rn);
                Grid.SetColumn(tp, cn);
                TeamsInfoGrid.Children.Add(tp);
            }
        }
    }
}
