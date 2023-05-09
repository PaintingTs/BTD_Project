using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTD.Patcher;

public interface IMapPatchingStrategy
{
    Action<string, string> ?_writer { get; set; }

    void LoadAdditionalPatchSettings(object? option);
    void Patch(ref string text);
}
