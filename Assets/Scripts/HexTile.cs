using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile
{
    //================================ Variables

    private bool empty;


    //Coordinates
    private HexCoordinates coordinates;

    //================================ Constructor
    public HexTile(HexCoordinates coordinates)
    {
        this.coordinates = coordinates;
        this.empty = true;
    }


    //================================ Methods

    public void ConstructBuilding()
    {

    }


    //================================ Getters & Setters
    public HexCoordinates GetCoordinates() { return this.coordinates; }
    public bool IsEmpty() { return this.empty; }
    public void SetEmpty(bool b) { this.empty = b; }
}
