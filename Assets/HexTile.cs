using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile
{
    //================================ Variables

    private string name;

    private float x;
    private float y;
    private float z;

    //================================ Constructor

    public HexTile(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    //================================ Methods

    public string CoordinateToString()
    {
        return (int)(this.x / 1.8f) + " , " + (int)(this.z / 1.565f);
    }

    //================================ Getters & Setters

    public void SetName(string name)
    {
        this.name = name;
    }

    public float GetX()
    {
        return this.x;
    }

    public float GetZ()
    {
        return this.z;
    }


}
