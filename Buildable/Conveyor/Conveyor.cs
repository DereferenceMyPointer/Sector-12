using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : Structure
{
    public Buildings.Side direction;
    private bool on;
    public float speed;

    private void Start()
    {
        on = true;
        InitializeItems();
        StartCoroutine(Process());
    }

    public IEnumerator Process()
    {
        while (on)
        {
            for(int i = 0; i < Resource.resources; i++)
            {
                if (inventory[i] > 0)
                {
                    inventory[i] -= Buildings.Instance.TransferResource(this, (Resource.Type)i, direction);
                }
            }
            yield return new WaitForSeconds(speed);
        }
    }

    public override int GiveResource(Resource.Type resource, int quantity, Buildings.Side sideFrom)
    {
        if(sideFrom == direction)
        {
            return 0;
        }
        return base.GiveResource(resource, quantity, sideFrom);
    }

}
