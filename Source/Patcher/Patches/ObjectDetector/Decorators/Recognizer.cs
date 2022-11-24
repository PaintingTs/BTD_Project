using System;
using System.Text.RegularExpressions;

namespace BTD.Patcher;

/// <summary>
/// Defines a strategy of handling different map objects types
/// </summary>
public interface IObjectRecognizingStrategy
{
    /// <summary>
    /// Regular expression that detects object's type
    /// </summary>
    static Regex _sharedRegex = new Regex("<Shared href=\"" + "(.*)" + "#");
    /// <summary>
    /// Regular expression that detects object's name
    /// </summary>
    static Regex _nameRegex = new Regex("<Name(.*)>");

    /// <summary>
    /// Delegate used for objects numeration
    /// </summary>
    Func<string, int> ?_numerator { get; set; }

    /// <summary>
    /// Initialize an instance of this strategy
    /// </summary>
    /// <param name="props">Initialization props</param>
    void Init(DetectorDecoratorProps props);

    /// <summary>
    /// Provides an alghoritm of handling a concrete type of map object.
    /// </summary>
    /// <param name="object_info">Information of object from map file</param>
    /// <returns>Generated string that will replace base object's definition in map file</returns>
    string? AnalyzeObject(string object_info);

    /// <summary>
    /// Returns a generated script string that describes objects handled by current strategy
    /// </summary>
    /// <returns>Generated script string</returns>
    string? GetScript();
}

public class ObjectRecognizer
{
    public ObjectRecognizer(string config)
    {

    }
}