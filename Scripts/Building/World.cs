using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public Vector2Int dimensions;

    private Resource.Type[,] resources;

    public static World Instance;

    private void OnEnable()
    {
        if(Instance == null)
        {
            Instance = this;
            Initialize();
        } else
        {
            Destroy(this);
        }
    }

    void Initialize()
    {
        resources = new Resource.Type[dimensions.x, dimensions.y];
        for(int x = 0; x < resources.GetUpperBound(0); x++)
        {
            for(int y = 0; y < resources.GetUpperBound(1); y++)
            {
                resources[x, y] = Resource.Type.Cubium;
            }
        }

        // grab placed resources?

    }

    public Resource.Type GetResourceAt(Vector2 location)
    {
        int x = Mathf.FloorToInt(location.x);
        int y = Mathf.FloorToInt(location.y);
        return resources[x, y];
    }

}
