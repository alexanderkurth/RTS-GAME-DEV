using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile
{
    //================================Variables

    private string name;

    private float x;
    private float y;
    private float z;

    //================================Constructor

    public HexTile(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    //================================Methods

    public string CoordinatesToString()
    {
        return this.x.ToString() + " , " + this.z.ToString();
    }

    //================================Getters & Setters


    public void SetName(string name)
    {
        this.name = name;
    }

    public float getX()
    {
        return this.x;
    }

    public float getZ()
    {
        return this.z;
    }

    public int getXCoord()
    {
        return (int) (this.x / 1.8f);
    }

    public int getZCoord()
    {
        return (int) (this.z / 1.565f);
    }
}
