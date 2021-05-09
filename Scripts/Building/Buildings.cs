using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.XR.WSA;

public class Buildings : MonoBehaviour
{
    public Vector2Int dimensions;
    public static Buildings Instance;
    private Structure[,] structures;

    public enum Side
    {
        TOP,
        BOTTOM,
        LEFT,
        RIGHT
    }

    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
            Initialize();
        }
        else
            Destroy(this);
    }

    void Initialize()
    {
        structures = new Structure[dimensions.x, dimensions.y];
        for (int x = 0; x < structures.GetUpperBound(0); x++)
        {
            for (int y = 0; y < structures.GetUpperBound(1); y++)
            {
                structures[x, y] = null;
            }
        }

        // grab placed buildings?

    }

    public bool RequestSpawn(Vector2 location, StructureType structure)
    {
        if (location.x < 0 || location.y < 0)
        {
            return false;
        }
        int x = Mathf.FloorToInt(location.x);
        int y = Mathf.FloorToInt(location.y);
        try
        {
            Vector2Int[] locations = GetLocations(location, structure.size);
            foreach (Vector2Int point in locations)
            {
                if (structures[point.x, point.y] != null)
                {
                    return false;
                }
            }

            Structure t = Instantiate(structure.prefab, new Vector3(x, y, 0), Quaternion.identity).transform.GetChild(0).GetComponent<Structure>();

            foreach (Vector2Int point in locations)
            {
                structures[point.x, point.y] = t;
            }
        } catch
        {
            return false;
        }
        return true;
    }

    public void RequestRemove(Structure t)
    {
        foreach(Structure o in structures)
        {
            if(t == o && t != null)
            {
                Destroy(t.gameObject);
            }
        }
    }

    public void RequestRemove(Vector2 location)
    {
        if(location.x < 0 || location.y < 0)
        {
            return;
        }
        int x = Mathf.FloorToInt(location.x);
        int y = Mathf.FloorToInt(location.y);
        RequestRemove(structures[x, y]);
    }

    private int RequestRemoveP(Vector2Int[] locations)
    {
        int numRemoved = 0;
        for(int i = 0; i < locations.Length; i++)
        {
            int x = Mathf.FloorToInt(locations[i].x);
            int y = Mathf.FloorToInt(locations[i].y);
            if (structures[x, y] != null)
            {
                Destroy(structures[x, y].gameObject);
                structures[x, y] = null;
                numRemoved++;
            }
        }
        return numRemoved;
    }

    public Structure GetStructure(Vector2 location)
    {
        int x = Mathf.FloorToInt(location.x);
        int y = Mathf.FloorToInt(location.y);
        return structures[x, y];
    }

    private Vector2Int[] GetLocations(Vector2 location, int size)
    {
        int x = Mathf.FloorToInt(location.x);
        int y = Mathf.FloorToInt(location.y);
        location.x = x;
        location.y = y;

        Vector2Int[] locations = new Vector2Int[size * size];

        int index = 0;
        for(int x1 = 0; x1 < size; x1++)
        {
            for (int y1 = 0; y1 < size; y1++)
            {
                if (x - x1 < 0 || y - y1 < 0)
                {
                    throw new Exception();
                }
                locations[index] = new Vector2Int(x - x1, y - y1);
                index++;
            }
        }

        return locations;

    }

    public int TransferResource(Structure source, Resource.Type resource, Side side)
    {
        Vector2Int[] sourceLocations = GetLocations(source.transform.position, source.type.size);
        int given = 0;
        Vector2Int direction = SideToDirection(side);
        foreach (Vector2Int location in sourceLocations)
        {
            Structure s = structures[location.x + direction.x, location.y + direction.y];
            if (s != source && s != null)
            {
                given += s.GiveResource(resource, 1, OppositeSide(side));
            }
        }
        return given;
    }

    public static Side DirectionToSide(Vector2Int direction)
    {
        if (direction == Vector2Int.up)
            return Side.TOP;
        if (direction == Vector2Int.down)
            return Side.BOTTOM;
        if (direction == Vector2Int.right)
            return Side.RIGHT;
        if (direction == Vector2Int.left)
            return Side.LEFT;
        throw new Exception("No such side exists");
    }

    public static Vector2Int SideToDirection(Side side)
    {
        switch (side)
        {
            case Side.TOP:
                return Vector2Int.up;
            case Side.BOTTOM:
                return Vector2Int.down;
            case Side.RIGHT:
                return Vector2Int.right;
            case Side.LEFT:
                return Vector2Int.left;
            default:
                return Vector2Int.zero;
        }
    }

    public static Side OppositeSide(Side side)
    {
        switch (side)
        {
            case Side.TOP:
                return Side.BOTTOM;
            case Side.BOTTOM:
                return Side.TOP;
            case Side.RIGHT:
                return Side.LEFT;
            case Side.LEFT:
                return Side.RIGHT;
            default:
                throw new Exception("No such side");
        }
    }

}
