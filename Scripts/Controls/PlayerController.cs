using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AttackCharacter c;
    public StructureType basicDrill;
    public StructureType conveyor;
    public bool mode;

    private StructureType structure;

    void Update()
    {
        c.target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        c.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        if (Input.GetButtonDown("Secondary"))
        {
            c.Perform("Secondary");
        }
        if (Input.GetButtonDown("Primary"))
        {
            c.Perform("Primary");
        }
        if (Input.GetButtonDown("Special"))
        {
            c.Perform("Special");
        }
        if (Input.GetButtonDown("Buildmode"))
        {
            if (mode)
            {
                c.SetState(new BuildState(this));
                mode = false;
            }
            else
            {
                c.SetState(new DefaultState(c));
                mode = true;
            }
        }
    }

    public void SetActiveBuilding(StructureType structure)
    {
        this.structure = structure;
    }

    public StructureType GetActiveBuidling()
    {
        return structure;
    }

}
