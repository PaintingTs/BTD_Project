using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTD.Patcher.MapInfo;

public class Map
{
    private string ?_mainDirectory;
    public string? MainDirectory
    {
        get { return _mainDirectory; }
        set { _mainDirectory = value; }
    }

    private string? _XdbFile { get; set; }
    public string? Xdb
    {
        get { return _XdbFile; }
        set { _XdbFile = value; }
    }

    private string? _Template { get; set; }
    public string? Template 
    { 
        get { return _Template; }
        set { _Template = value; }
    }
}