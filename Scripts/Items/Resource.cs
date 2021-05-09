using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource
{
    public enum Type
    {
        Minerite,
        Xytan,
        Cubium,
        Oxyte,
        Throntite,
        Bonetium
    }

    public static int resources = 3;

    public static Dictionary<Type, string> resourceNames = new Dictionary<Type, string>()
    {
        {Type.Cubium, "Cubium" },
        {Type.Minerite, "Minerite" },
        {Type.Xytan, "Xytan" },
        {Type.Bonetium, "Bonetium" },
        {Type.Oxyte, "Oxyte" },
        {Type.Throntite, "Throntite" }
    };
}
