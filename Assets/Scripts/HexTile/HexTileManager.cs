using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTileManager : MonoBehaviour
{
    //================================ Variables

    [Header("Building Management")]
    public BuildingHandler buildingHandler;

    [Header("HighLight Color")]
    [SerializeField] private int redColor ;
    [SerializeField] private int greenColor ;
    [SerializeField] private int blueColor ;

    [Header("HighLight Management")]
    [SerializeField] private bool startedFlashing = false;
    [SerializeField] private bool flashingIn = true;
    [SerializeField] private bool lookingAtObject = false;

    public static HexTileManager ins;

    //================================ Methods

    void Awake()
    {
        ins = this;
    }

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
        while (lookingAtObject)
        {
            yield return new WaitForSeconds(0.1f);
            if (flashingIn)
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
            if (!flashingIn)
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
            Building b2;
            b2 = buildingHandler.GetSimpleBuilding();
            b = (Instantiate(b2, new Vector3(transform.position.x, 0.5f, transform.position.z), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f))) ;
            SetBuilding(b);
        }
    }

    public void DestroyBuilding()
    {
        if(GetHexTile().GetBuilding()!=null)
        {
            Destroy(GetHexTile().GetBuilding());
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
