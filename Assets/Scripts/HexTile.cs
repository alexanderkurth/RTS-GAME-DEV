using UnityEngine;

public class HexTile : MonoBehaviour
{
    //================================ Variables

    private bool empty;
    private string hexTileName;

    //Tile Management
    public bool selected;

    //Buildings
    private bool buildable;
    private Building building;

    //Coordinates
    private HexCoordinates coordinates;

    //================================ Methods

    //================================ Getters & Setters

    public HexCoordinates GetCoordinates() { return this.coordinates; }
    public void SetHexCoordinates(HexCoordinates hc) { this.coordinates = hc; }

    public bool IsEmpty() { return this.empty; }
    public void SetEmpty(bool b) { this.empty = b; }

    public bool IsSelected() { return this.selected; }
    public void SetSelected(bool b) { this.selected = b; }

    public bool IsBuildable() { return this.buildable; }
    public void SetBuildable(bool b) { this.buildable = b; }

    public Building GetBuilding() { return this.building; }
    public void SetBuilding(Building building) { this.building = building; }

    public string GetHexTileName() { return this.hexTileName; }
    public void SetHexTileName(string name) { this.hexTileName = name; }


}
