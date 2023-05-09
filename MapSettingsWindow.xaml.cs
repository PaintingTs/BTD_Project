using System.IO;
using System.Windows;

using Newtonsoft.Json;

using BTD.Patcher.UI;
using BTD.Patcher.MapInfo;
public struct MapSettingsWindowModel
{
    public bool? _useNightLight { get; set; }
    public MapSettingsWindowModel()
    {
        _useNightLight = false;
    }

}

namespace Patcher
{
    /// <summary>
    /// Логика взаимодействия для MapSettingsWindow.xaml
    /// </summary>
    public partial class MapSettingsWindow : Window
    {
        private MapSettingsFascade ?_currentFascade;
        public MapSettingsWindow()
        {
            InitializeComponent();

            Closed += (o, e) => SaveSettings();

            MapSettingsWindowModel currentSettings = JsonConvert.DeserializeObject<MapSettingsWindowModel>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\cfg\\CurrentMap\\settings.json"));
            NightLightCheckBox.IsChecked = currentSettings._useNightLight;
        }

        private void SaveSettings()
        {
            MapSettingsWindowModel currentSettings = new MapSettingsWindowModel();
            currentSettings._useNightLight = NightLightCheckBox.IsChecked;
            string settingsText = JsonConvert.SerializeObject(currentSettings, Formatting.Indented);
            File.WriteAllText(Directory.GetCurrentDirectory() + "\\cfg\\CurrentMap\\settings.json", settingsText);
        }

        public void Init(MapSettingsFascade fascade)
        {
            _currentFascade = fascade;

            NightLightCheckBox.Checked += _currentFascade.NightLight_Checked;
        }
    }
}
