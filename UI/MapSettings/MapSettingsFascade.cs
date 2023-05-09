using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Reflection;
using System;

using Newtonsoft.Json;
using static BTD.Patcher.UI.IMapOptionsModifier;
using BTD.Patcher.MapInfo;

namespace BTD.Patcher.UI;

public interface IMapOptionsModifier
{
    public delegate void OnMapOptionChanged(string name, object? value);
    public event OnMapOptionChanged MapOptionChanged;

    //public object? RequestMapOption(string name, object? value);
}

public class MapSettingsFascade : IMapOptionsModifier
{
    public event OnMapOptionChanged ?MapOptionChanged;

    public void SetupNewMapInfo(MapBaseInfo info)
    {
        MapSettingsWindowModel newSettingsModel = new MapSettingsWindowModel();
        string newModelString = JsonConvert.SerializeObject(newSettingsModel, Formatting.Indented);
        File.WriteAllText(Directory.GetCurrentDirectory() + "\\cfg\\CurrentMap\\settings.json", newModelString);
    }

    public void NightLight_Checked(object sender, RoutedEventArgs e)
    {
        MapOptionChanged!("useNightLight", (sender as CheckBox)!.IsChecked == true);
    }
}