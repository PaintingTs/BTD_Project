using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTD.Patcher.MapInfo;

public class MapBaseInfo
{
    private string ?_name;
    public string name
    {
        get { return _name!; }
        set { _name = value; }
    }

    private string? _directory;
    public string directory
    {
        get { return _directory!; }
        set { _directory = value; }
    }

    private string? _template;
    public string template
    {
        get { return _template!; }
        set { _template = value; }
    }

    private string? _playersCount;
    public string playersCount
    {
        get { return _playersCount!; }
        set { _playersCount = value; }
    }
}

public class MapFilesInfo
{
    private string? _mainXdb;
    public string mainXdb
    {
        get { return _mainXdb!; }
        set { _mainXdb = value; }
    }

    private string? _mapTag;
    public string mapTag
    {
        get { return _mapTag!; }
        set { _mapTag = value; }
    }
}

public class MapPatchOptions
{
    private bool _useNightLight;
    public bool useNightLight
    {
        get { return _useNightLight; }
        set { _useNightLight = value; }
    }

    private Dictionary<int, int> _playersTeamInfo;
    public Dictionary<int, int> playersTeamInfo
    {
        get { return _playersTeamInfo; }
        set { _playersTeamInfo = value; }
    }

    public MapPatchOptions()
    {
        _useNightLight = false;
        _playersTeamInfo = new Dictionary<int, int>();
    }
}