using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTD.Patcher.MapInfo;
public interface IMapInfoDetector
{
    bool CanBeDetected(string path);
    string? DetectValue(string path);
}
