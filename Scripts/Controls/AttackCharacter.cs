using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCharacter : ItemCharacter
{
    [Header("Components")]
    public Rigidbody2D rb;
    public List<GameObject> allAttacks;

    private Dictionary<string, Item> items;
    private Dictionary<string, IAttack> attacks;
    private ICharacterState currentState;
        
    void OnEnable()
    {
        items = new Dictionary<string, Item>();
        InitializeItems();
        attacks = new Dictionary<string, IAttack>();
        foreach(GameObject attack in allAttacks)
        {
            attacks.Add(attack.name, attack.GetComponent<IAttack>());
        }
        currentState = new DefaultState(this);
    }

    public override bool Damage(float amount)
    {
        Damaged();
        return false;
    }

    public void Move(Vector3 direction)
    {
        rb.velocity = direction.normalized * CalculateSpeed();
        if(direction.x != 0)
        {
            Flip();
        }
        if(direction != Vector3.zero)
        {
            anim.SetBool("Walk", true);
        } else
        {
            anim.SetBool("Walk", false);
        }
    }

    public override void Perform(string type)
    {
        currentState.Perform(type);
    }

    public override void Attack(string type)
    {
        attacks[type].Use(target);
    }

    public void SetState(ICharacterState state)
    {
        currentState.End();
        currentState = state;
        currentState.Start();
    }

    void Flip()
    {
        graphics.localScale = new Vector3(Mathf.Sign(rb.velocity.x), 1, 0);
    }

    float CalculateRegen()
    {
        float value = settings.baseRegen;
        foreach(Item i in items.Values)
        {
            value *= i.RegenBuff;
        }
        return value;
    }

    float CalculateSpeed()
    {
        float value = settings.baseSpeed;
        foreach (Item i in items.Values)
        {
            value *= i.SpeedBuff;
        }
        return value;
    }
    float CalculateDamage()
    {
        float value = settings.baseDamage;
        foreach (Item i in items.Values)
        {
            value *= i.DamageBuff;
        }
        return value;
    }
}
