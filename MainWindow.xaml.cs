using BTD.Patcher;
using BTD.Patcher.UI;
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

using BTD.Patcher.MapInfo;

namespace BTD_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PatcherFascade _patcherFascade = new PatcherFascade();

        public MainWindow()
        {
            InitializeComponent();

            Closed += (o, e) => Application.Current.Shutdown();

            MapInfoGrid.Visibility = Visibility.Hidden;
            Patcher_StartPatchButton.IsEnabled = false;

            Patcher_MapPickButton.Click += _patcherFascade.MapPickButtonClicked;
            Patcher_StartPatchButton.Click += _patcherFascade.StartPatchButtonClicked;
            Patcher_StartPatchButton.Click += (o, e) => MessageBox.Show("Обработка успешно завершена!");
            TeamBuilderButton.Click += _patcherFascade.TeamBuilderButtonClicked;
            AdditionalMapSettingsButton.Click += _patcherFascade.MapSettingsButtonClicked;
            _patcherFascade.MapAssigned += DisplayMapInfo;
        }
        private void DisplayMapInfo(MapBaseInfo info)
        {
            MapInfoGrid.Visibility = Visibility.Visible;
            Patcher_StartPatchButton.IsEnabled = true;

            MapInfo_PlayerCountLabel.Content = info.playersCount;
            if (Convert.ToInt32(info.playersCount) > 2)
            {
                TeamBuilderButton.Visibility = Visibility.Visible;
                TeamBuilderButton.IsEnabled = true;
            }
            MapInfo_TemplateNameLabel.Content = info.template;
            MapInfo_MapNameLabel.Content = info.name;
        }
    }
}
