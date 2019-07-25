using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTileManager : MonoBehaviour
{
    //================================ Variables

    public Building building;

    //================================ Methods

    public void Build()
    {
        if(GetHexTile().IsBuildable() && GetHexTile().GetBuilding() == null)
        {
            Building b;
            b = (Instantiate(building, new Vector3(GetComponent<Renderer>().bounds.center.x, 0.5f, GetComponent<Renderer>().bounds.center.z), Quaternion.identity));
            SetBuilding(b);
            b.gameObject.transform.parent = GetHexTile().gameObject.transform;
        }
    }

    private bool CheckBuildingOnTile()
    {
        return GetComponent<HexTile>().GetBuilding();
    }

    //================================ Getters & Setters
    public Material GetMaterial() { return GetComponent<Renderer>().material; }
    public void SetMaterialColor(Color c) { GetComponent<Renderer>().material.color = c; }

    public HexTile GetHexTile() { return GetComponent<HexTile>(); }

    public bool IsSelected() { return GetComponent<HexTile>().IsSelected(); }
    public void SetSelected(bool b) { GetComponent<HexTile>().SetSelected(b); }

    public void SetBuilding(Building building) { GetComponent<HexTile>().SetBuilding(building); }

}
