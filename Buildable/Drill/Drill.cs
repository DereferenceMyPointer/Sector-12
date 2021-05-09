using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Drill : Structure
{
    public Resource.Type[] available;
    public float drillSpeed;
    public bool on;

    private void Start()
    {
        target = transform.position;
        StartCoroutine(StartDrill());
    }

    private IEnumerator StartDrill()
    {
        while (on)
        {
            Resource.Type targetResource = World.Instance.GetResourceAt(target);
            if (available.Contains(targetResource))
            {
                GiveResource(targetResource, 1);
                MoveResources();
            }
            yield return new WaitForSeconds(drillSpeed);
        }
    }

    private void MoveResources()
    {
        for(int i = 0; i < Resource.resources; i++)
        {
            if(inventory[i] > 0)
            {
                inventory[i] -= Buildings.Instance.TransferResource(this, (Resource.Type)i, Buildings.Side.TOP);
                inventory[i] -= Buildings.Instance.TransferResource(this, (Resource.Type)i, Buildings.Side.BOTTOM);
                inventory[i] -= Buildings.Instance.TransferResource(this, (Resource.Type)i, Buildings.Side.RIGHT);
                inventory[i] -= Buildings.Instance.TransferResource(this, (Resource.Type)i, Buildings.Side.LEFT);
            }
        }
    }

    public override int GiveResource(Resource.Type resource, int quantity, Buildings.Side side)
    {
        return 0;
    }

    public void GiveResource(Resource.Type resource, int quantity)
    {
        inventory[(int)resource] += quantity;
    }

}
