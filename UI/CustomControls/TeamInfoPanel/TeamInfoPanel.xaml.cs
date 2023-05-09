using System;
using System.Collections.Generic;
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

namespace Patcher.UI.CustomControls.TeamInfoPanel
{
    /// <summary>
    /// Логика взаимодействия для TeamInfoPanel.xaml
    /// </summary>
    public partial class TeamInfoPanel : UserControl
    {
        public TeamInfoPanel()
        {
            InitializeComponent();
        }

        public void Setup(int team_num)
        {
            TeamName_Label.Content = "Команда " + team_num.ToString();
            PlayerCount_Label.Content = 1.ToString();
        }
    }
}
