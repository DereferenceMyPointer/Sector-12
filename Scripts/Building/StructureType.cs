using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Structure", menuName = "Structure Type")]
public class StructureType : ScriptableObject
{
    public GameObject prefab;
    public Sprite icon;
    public Resource.Type[] requirements;
    public int[] costs;
    public string structureName;
    public int size;
}
