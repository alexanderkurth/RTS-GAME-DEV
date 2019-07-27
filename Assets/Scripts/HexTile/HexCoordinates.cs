using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct HexCoordinates
{
    //================================ Getters & Setters

    public int X { get; private set; }
    public int Z { get; private set; }
    public int Y { get { return -X - Z; } }

    //================================ Constructor

    public HexCoordinates(int x, int z)
    {
        X = x;
        Z = z;
    }

    //================================ Methods

    public static HexCoordinates FromOffsetCoordinates(int x, int z)
    {
        return new HexCoordinates(x - z / 2, z);
    }

    public override string ToString()
    {
        return X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() ;
    }
}