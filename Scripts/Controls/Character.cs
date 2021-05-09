using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Character
{
    event EventHandler OnAttack;
    event EventHandler OnKill;
    event EventHandler OnDealDamage;
    event EventHandler OnReceiveDamage;
    event EventHandler OnDeath;

    void Death();

    void Killed();

    void Attacked();

    void Damaged();

    void DamageReceived();

    bool Damage(float amount);

    void Attack(string type);

    void PickUp(Item item);

    int GiveResource(Resource.Type resource, int quantity, Buildings.Side sideFrom);

    Vector2 Target();

    Vector2 Position();
    
}
