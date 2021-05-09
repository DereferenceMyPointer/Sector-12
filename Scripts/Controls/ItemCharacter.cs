using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCharacter : MonoBehaviour, Character
{
    [Header("Components")]
    public Transform graphics;
    public Animator anim;
    public CharacterSettings settings;
    public GameObject itemObject;

    public int[] inventory = new int[20];

    private Dictionary<string, Item> items;

    public Vector2 target;

    public event EventHandler OnAttack;
    public event EventHandler OnKill;
    public event EventHandler OnDealDamage;
    public event EventHandler OnReceiveDamage;
    public event EventHandler OnDeath;

    private void OnEnable()
    {
        InitializeItems();
    }

    protected void InitializeItems()
    {
        items = new Dictionary<string, Item>();
        foreach (Item item in itemObject.GetComponents<Item>())
        {
            if (!items.ContainsKey(item.ItemName))
                items.Add(item.ItemName, item);
        }
    }

    public void Killed()
    {
        OnKill?.Invoke(this, EventArgs.Empty);
    }

    public void Attacked()
    {
        OnAttack?.Invoke(this, EventArgs.Empty);
    }

    public void Damaged()
    {
        OnDealDamage?.Invoke(this, EventArgs.Empty);
    }

    public void DamageReceived()
    {
        OnReceiveDamage.Invoke(this, EventArgs.Empty);
    }

    public virtual void Perform(string type)
    {
        
    }

    public void PickUp(Item item)
    {
        items[item.ItemName].Quantity += 1;
    }

    public bool RemoveItem(Item item)
    {
        if (items[item.ItemName].Quantity > 0)
        {
            items[item.ItemName].Quantity -= 1;
            return true;
        }
        return false;
    }

    public virtual bool Damage(float amount)
    {
        return false;
    }

    public virtual void Attack(string type)
    {
        throw new NotImplementedException();
    }

    public Vector2 Position()
    {
        return transform.position;
    }

    public Vector2 Target()
    {
        return target;
    }

    protected float CalculateHealth()
    {
        float value = settings.baseHealth;
        foreach (Item i in items.Values)
        {
            value *= i.HealthBuff;
        }
        return value;
    }

    public virtual int GiveResource(Resource.Type resource, int quantity, Buildings.Side sideFrom)
    {
        inventory[(int)resource] += quantity;
        return quantity;
    }

    public void Death()
    {
        OnDeath?.Invoke(this, EventArgs.Empty);
    }
}
