using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BTD.Patcher;
public class MapPicker
{
    public delegate void OnMapPicked(string map_path);
    public event OnMapPicked ?MapPicked;

    public void StartPick()
    {
        OpenFileDialog _mapPickDialog = new OpenFileDialog();
        _mapPickDialog.Title = "Выберите карту, которую хотите обработать";
        _mapPickDialog.Filter = "Файлы карт (*h5m)|*.h5m";
        if(_mapPickDialog.ShowDialog() == true)
        {
            MapPicked!(_mapPickDialog.FileName);
        }
    }
}
