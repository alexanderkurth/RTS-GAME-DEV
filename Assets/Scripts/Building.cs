using UnityEngine;

public class Building : MonoBehaviour
{
    //================================ Variables
    public HexCoordinates hexCoordinates;
    public string buildingName;

    //================================ Methods

    //================================ Getters & Setters
    public HexCoordinates GetHexCoordinates() { return this.hexCoordinates; }
    public void SetHexcoordinates(HexCoordinates hexCoordinates) { this.hexCoordinates = hexCoordinates; }
    public string GetBuildingName() { return this.buildingName; }
    public void SetBuildingName(string name) { this.buildingName = name; }






}
