using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float hitDamage;
    public float lifetime;
    public Character source;
    public Rigidbody2D rb;

    private void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime <= 0)
        {
            SelfDestruct();
        }
    }

    public virtual void SelfDestruct()
    {
        Destroy(this.gameObject);
    }

    public virtual void OnHit(Collider2D collision)
    {
        if(collision.TryGetComponent<Character>(out Character c))
        {
            source.Damaged();
            if (c.Damage(hitDamage))
                source.Killed();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnHit(collision);
    }

}
