using System;

namespace TerraTemp.Custom.Attributes {

    /// <summary>
    /// Attribute that is used to ignore this given subclass in the GetAllChildrenOfClass() method
    /// in TempUtilities.cs
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class IgnoredSubclassAttribute : Attribute { }
}