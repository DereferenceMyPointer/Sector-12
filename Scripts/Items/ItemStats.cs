using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "Item/Base")]
public class ItemStats : ScriptableObject
{
    public new string name;

    public float healthBuff;
    public float regenBuff;

    public float damageBuff;
    public float attackSpeedBuff;

    public float speedBuff;

    public Sprite icon;
    public Sprite tile;

}
