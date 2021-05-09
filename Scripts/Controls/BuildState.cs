using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildState : ICharacterState
{
    public PlayerController c;
    public AttackCharacter a;

    public BuildState(PlayerController c)
    {
        this.c = c;
        this.a = c.c;
    }

    public void End()
    {
        
    }
        
    public void Perform(string type)
    {
        switch (type)
        {
            case "Primary":
                Buildings.Instance.RequestSpawn(a.target, c.GetActiveBuidling());
                break;
            case "Secondary":
                Buildings.Instance.RequestRemove(a.target);
                break;
            case "Special":
                Buildings.Instance.RequestSpawn(a.target, c.conveyor);
                break;
        }
        if (type.Equals("Primary"))
        {
            Buildings.Instance.RequestSpawn(a.target, c.basicDrill);
        }
    }

    public void Start()
    {
        
    }

    public void Update()
    {
        
    }
}
