using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using BTD.Patcher.MapInfo;
using Newtonsoft.Json;
using Patcher;

namespace BTD.Patcher.UI;

/// <summary>
/// Основной фасад патчера, соединяющий процесса патчинга с главным и дополнительными элементами интерфейса
/// </summary>
public class PatcherFascade
{
    #region patcher_elements
    private Patcher _mapPatcher = new Patcher();
    private MapPicker _mapPicker = new MapPicker();
    private MapUnpacker _mapUnpacker = new MapUnpacker();

    private MapBaseInfo ?_mapBaseInfo;
    private MapFilesInfo ?_mapFilesInfo;
    private MapPatchOptions ?_mapPatchOptions;
    #endregion

    #region additional_ui_elements
    private TeamBuilderWindow _teamBuilderWindow = new TeamBuilderWindow();
    private TeamBuilderFascade _teamBuilderFascade = new TeamBuilderFascade();

    private MapSettingsFascade _mapSettingsFascade = new MapSettingsFascade();
    #endregion

    #region events
    public delegate void OnMapAssigned(MapBaseInfo info);
    public event OnMapAssigned? MapAssigned;
    #endregion 

    public PatcherFascade()
    {
        _mapPicker.MapPicked += _mapUnpacker.Unpack;
        _mapUnpacker.MapUnpacked += AssignMap;
        _mapPatcher.MapPatched += _mapUnpacker.Clean;

        _mapSettingsFascade.MapOptionChanged += UpdateMapParameter;
        _teamBuilderFascade.MapOptionChanged += UpdateMapParameter;
        MapAssigned += _mapSettingsFascade.SetupNewMapInfo;
    }

    // фасад должен уметь реагировать на нажатие кнопки старта пика
    public void MapPickButtonClicked(object sender, RoutedEventArgs e)
    {
        _mapPicker.StartPick();
    }

    // фасад должен уметь реагировать на нажатие кнопки старта патча
    public void StartPatchButtonClicked(object sender, RoutedEventArgs e)
    {
        _mapPatcher.Run(_mapBaseInfo!, _mapFilesInfo!, _mapPatchOptions!);
    }

    // фасад должен уметь реагировать на нажатие кнопки распределителя команд(перенести в отдельный?)
    public void TeamBuilderButtonClicked(object sender, RoutedEventArgs e)
    {
        _teamBuilderFascade.Init(Convert.ToInt32(_mapBaseInfo!.playersCount));
        _teamBuilderWindow.Init(_teamBuilderFascade);
        _teamBuilderWindow.Show();
    }

    public void MapSettingsButtonClicked(object sender, RoutedEventArgs e)
    {
        MapSettingsWindow _mapSettingsWindow = new MapSettingsWindow();
        _mapSettingsWindow.Init(_mapSettingsFascade);
        _mapSettingsWindow.Show();
    }

    private void AssignMap(MapBaseInfo baseInfo, MapFilesInfo filesInfo)
    {
        _mapBaseInfo = baseInfo;
        _mapFilesInfo = filesInfo;
        _mapPatchOptions = new MapPatchOptions();
        MapAssigned!(_mapBaseInfo);
    }

    private void UpdateMapParameter(string name, object? value)
    {
        Type mapType = _mapPatchOptions!.GetType();
        PropertyInfo mapProperty = mapType.GetProperty(name)!;
        if(mapProperty != null)
        {
            mapProperty.SetValue(_mapPatchOptions, value);
        }
    }
}
