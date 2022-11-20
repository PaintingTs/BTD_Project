using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTD;

public static class Path
{
    public static readonly string Main = Directory.GetCurrentDirectory().Replace("bin\\Debug\\net7.0-windows", "");
    public static readonly string Source = Main + "Source\\";
}