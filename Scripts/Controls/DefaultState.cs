using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultState : ICharacterState
{
    private AttackCharacter c;

    public DefaultState(AttackCharacter c)
    {
        this.c = c;
    }

    public void End()
    {
        
    }

    public void Perform(string type)
    {
        switch (type)
        {
            case "Primary":
                c.anim.SetTrigger("Attack1");
                c.Attack("Attack1");
                break;
        }
    }

    public void Start()
    {
        
    }

    public void Update()
    {
        
    }
}
