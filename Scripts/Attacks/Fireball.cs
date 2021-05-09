using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour, IAttack
{
    public GameObject character;
    private Character c;
    public float speed;
    public float range;
    public GameObject prefab;

    void OnEnable()
    {
        c = character.GetComponent<Character>();
    }

    public void Use(Vector2 target)
    {
        Vector2 direction = target - c.Position();
        direction = direction.normalized;
        Projectile p = Instantiate(prefab, c.Position() + direction, Quaternion.FromToRotation(Vector3.right, new Vector3(direction.x, direction.y, 0))).GetComponent<Projectile>();
        p.lifetime = range / speed;
        p.rb.velocity = direction.normalized * speed;
        p.source = c;
    }
}
