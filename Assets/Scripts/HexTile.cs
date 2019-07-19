using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour
{
    //================================ Variables

    [SerializeField]bool empty;
    [SerializeField]string hexTileName;

    //Coordinates
    private HexCoordinates coordinates;

    //================================ Methods

    //================================ Getters & Setters
    public HexCoordinates GetCoordinates() { return this.coordinates; }
    public void SetHexCoordinates(HexCoordinates hc) { this.coordinates = hc; }
    public bool IsEmpty() { return this.empty; }
    public void SetEmpty(bool b) { this.empty = b; }

    public string GetHexTileName() { return this.hexTileName; }
    public void SetHexTileName(string name) { this.hexTileName = name; }
}
