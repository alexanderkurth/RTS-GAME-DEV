using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTileManager : MonoBehaviour
{
    //================================ Variables

    public Building building;

    private int redColor ;
    private int greenColor ;
    private int blueColor ;

    public bool startedFlashing = false;
    private bool flashingIn = true;
    public bool lookingAtObject = false;

    //================================ Methods

    void Start()
    {
        redColor = (int)GetComponent<Renderer>().material.color.r;
        greenColor = (int)GetComponent<Renderer>().material.color.g;
        blueColor = (int)GetComponent<Renderer>().material.color.b;
    }

    void Update()
    {
        if(IsSelected())
        {
            GetComponent<Renderer>().material.color = new Color32((byte)redColor, (byte)greenColor, (byte)blueColor, 255);
            lookingAtObject = true;

            if (!startedFlashing)
            {
                startedFlashing = true;
                StartCoroutine(FlashObject());
            }
        }
        else
        {
            startedFlashing = false;
            lookingAtObject = false;
            GetComponent<Renderer>().material.color = new Color32(160, 160, 160, 255);
            StopCoroutine(FlashObject());
        }
    }

    IEnumerator FlashObject()
    {
        while (lookingAtObject == true)
        {
            yield return new WaitForSeconds(0.1f);
            if (flashingIn == true)
            {
                if (blueColor <= 160)
                {
                    flashingIn = false;
                }
                else
                {
                    blueColor -= 25;
                    redColor -= 25;
                    greenColor -= 25;
                }
            }
            if (flashingIn == false)
            {
                if (blueColor >= 250)
                {
                    flashingIn = true;
                }
                else
                {
                    blueColor += 25;
                    redColor += 25;
                    greenColor += 25;
                }
            }

        }
    }

    public void Build()
    {
        if(GetHexTile().IsBuildable() && GetHexTile().GetBuilding() == null)
        {
            Building b;
            b = (Instantiate(building, new Vector3(transform.position.x, 0.5f, transform.position.z), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f))) ;
            SetBuilding(b);
        }
    }

    private bool CheckBuildingOnTile()
    {
        return GetComponent<HexTile>().GetBuilding();
    }

    public void Glow()
    {

    }

    //================================ Getters & Setters
    public Material GetMaterial() { return GetComponent<Renderer>().material; }
    public void SetMaterialColor(Color c) { GetComponent<Renderer>().material.color = c; }

    public HexTile GetHexTile() { return GetComponent<HexTile>(); }

    public bool IsSelected() { return GetComponent<HexTile>().IsSelected(); }
    public void SetSelected(bool b) { GetComponent<HexTile>().SetSelected(b); }

    public void SetBuilding(Building building) { GetComponent<HexTile>().SetBuilding(building); }

}
