using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour
{
    //================================ Variables

    public bool empty;
    public string hexTileName;

    //Coordinates
    public HexCoordinates coordinates;

    //================================ Constructor
    public HexTile(HexCoordinates coordinates)
    {
        this.coordinates = coordinates;
        this.empty = true;
    }


    //================================ Methods

    //================================ Getters & Setters
    public HexCoordinates GetCoordinates() { return this.coordinates; }
    public void SetHexCoordinates(HexCoordinates hc) { this.coordinates = hc; }
    public bool IsEmpty() { return this.empty; }
    public void SetEmpty(bool b) { this.empty = b; }
}
