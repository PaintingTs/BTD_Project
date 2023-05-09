using BTD.Patcher.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BTD_Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\cfg\\CurrentMap\\"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\cfg\\CurrentMap\\");
            }
        }
    }
}
