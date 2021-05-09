using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName, itemDescription;
    [SerializeField]
    private float healthBuff, regenBuff, damageBuff, attackSpeedBuff, speedBuff = 1f;

    [SerializeField]
    private Sprite icon, tile;

    [SerializeField]
    private int quantity = 1;

    public string ItemName { get => itemName; set => itemName = value; }
    public string ItemDescription { get => itemName; set => itemName = value; }
    public float HealthBuff { get => healthBuff * Quantity; set => healthBuff = value; }
    public float RegenBuff { get => regenBuff * Quantity; set => regenBuff = value; }
    public float DamageBuff { get => damageBuff * Quantity; set => damageBuff = value; }
    public float AttackSpeedBuff { get => attackSpeedBuff * Quantity; set => attackSpeedBuff = value; }
    public float SpeedBuff { get => speedBuff * Quantity; set => speedBuff = value; }
    public Sprite Icon { get => icon; set => icon = value; }
    public Sprite Tile { get => tile; set => tile = value; }
    public int Quantity { get => quantity; set => quantity = value; }

}
