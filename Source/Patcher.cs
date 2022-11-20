using System.Diagnostics;
using BTD.Patcher.MapInfo;
namespace BTD.Patcher;

public class Patcher
{

    public void Run(Map map)
    {
        Trace.WriteLine("Running patcher ");
        Trace.WriteLine("Map xdb - " + map.Xdb + ", template is " + map.Template);
    }
}