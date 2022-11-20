using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using BTD.Patcher.MapInfo;

namespace BTD.Patcher.UI;
public class PatcherFascade
{
    private Patcher _mapPatcher = new Patcher();
    private MapPicker _mapPicker = new MapPicker();
    private MapUnpacker _mapUnpacker = new MapUnpacker();

    public PatcherFascade()
    {
        _mapPicker.MapPicked += _mapUnpacker.Unpack;
        _mapUnpacker.MapUnpacked += _mapPatcher.Run;
    }

    // фасад должен уметь реагировать на нажатие кнопки старта пика
    public void MapPickButtonClicked(object sender, RoutedEventArgs e)
    {
        _mapPicker.StartPick();
    }

    // фасад должен уметь реагировать на нажатие кнопки старта патча
    public void StartPatchButtonClicked(object sender, RoutedEventArgs e)
    {

    }
}
