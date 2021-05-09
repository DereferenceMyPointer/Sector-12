using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Settings", menuName ="Settings/Character Settings")]
public class CharacterSettings : ScriptableObject
{
    public float baseSpeed = 1;
    public float baseDamage = 1;
    public float baseRegen = 1;
    public float baseHealth = 1;
    public float levelScaling = 1;
}
