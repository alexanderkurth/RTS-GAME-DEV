using System.Collections;
using UnityEngine;

public class HexTileManager : MonoBehaviour//TODO[Refactor] take all color insteds of 1 
{
    //================================ Variables

    [Header("Building Management")]
    public BuildingHandler buildingHandler;

    [Header("HighLight Color")]

    [SerializeField] private float[] redColorArray;
    [SerializeField] private float[] greenColorArray;
    [SerializeField] private float[] blueColorArray;

    [SerializeField] private float[] redColorArray2;
    [SerializeField] private float[] greenColorArray2;
    [SerializeField] private float[] blueColorArray2;

    [Header("HighLight Management")]
    [SerializeField] private bool startedFlashing = false;
    [SerializeField] private bool flashingIn = true;
    [SerializeField] private bool lookingAtObject = false;

    Color[] r, g, b;

    public static HexTileManager ins;

    //================================ Methods

    void Awake()
    {
        ins = this;
    }

    void Start()
    {
        r = new Color[GetComponent<Renderer>().materials.Length];
        g = new Color[GetComponent<Renderer>().materials.Length];
        b = new Color[GetComponent<Renderer>().materials.Length];


        redColorArray = new float[GetComponent<Renderer>().materials.Length];
        greenColorArray = new float[GetComponent<Renderer>().materials.Length];
        blueColorArray = new float[GetComponent<Renderer>().materials.Length];

        redColorArray2 = new float[GetComponent<Renderer>().materials.Length];
        greenColorArray2 = new float[GetComponent<Renderer>().materials.Length];
        blueColorArray2 = new float[GetComponent<Renderer>().materials.Length];

        for (int i = 0; i < GetComponent<Renderer>().materials.Length; i++)
        {
            redColorArray[i] = GetComponent<Renderer>().materials[i].color.r;
            greenColorArray[i] = GetComponent<Renderer>().materials[i].color.g;
            blueColorArray[i] = GetComponent<Renderer>().materials[i].color.b;

            redColorArray2[i] = GetComponent<Renderer>().materials[i].color.r;
            greenColorArray2[i] = GetComponent<Renderer>().materials[i].color.g;
            blueColorArray2[i] = GetComponent<Renderer>().materials[i].color.b;

            r[i] = GetComponent<Renderer>().materials[i].color;
            g[i] = GetComponent<Renderer>().materials[i].color;
            b[i] = GetComponent<Renderer>().materials[i].color;

        }
    }

    void Update()
    {
        if (IsSelected())
        {

            for (int i = 0; i < GetComponent<Renderer>().materials.Length; i++)
            {
                GetComponent<Renderer>().materials[i].color = new Color32((byte)redColorArray[i], (byte)greenColorArray[i], (byte)blueColorArray[i], 255);
            }
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

            for (int i = 0; i < GetComponent<Renderer>().materials.Length; i++)
            {
                //GetComponent<Renderer>().materials[i].color = new Color32(160, 160, 160, 255);    
                GetComponent<Renderer>().materials[i].color = r[i];    
                //GetComponent<Renderer>().materials[i].SetColor( new Color32((byte)redColorArray2[i], (byte)greenColorArray2[i], (byte)blueColorArray2[i], 255));

            }
            StopCoroutine(FlashObject());
        }
    }

    IEnumerator FlashObject()
    {
        while (lookingAtObject)
        {
            yield return new WaitForSeconds(0.1f);
            for (int i = 0; i < GetComponent<Renderer>().materials.Length; i++)
            {
                if (flashingIn)
                {
                    if (blueColorArray[i] <= 160)
                    {
                        flashingIn = false;
                    }
                    else
                    {
                        blueColorArray[i] -= 25;
                        redColorArray[i] -= 25;
                        greenColorArray[i] -= 25;
                    }
                }
                if (!flashingIn)
                {
                    if (blueColorArray[i] >= 250)
                    {
                        flashingIn = true;
                    }
                    else
                    {
                        blueColorArray[i] += 25;
                        redColorArray[i] += 25;
                        greenColorArray[i] += 25;
                    }
                }
            }
        }
    }

    //[TODO] Refactor 
    public void Build(Building b3)
    {
        if (GetHexTile().IsBuildable() && GetHexTile().GetBuilding() == null)
        {
            Building b;

            b = (Instantiate(b3, new Vector3(transform.position.x, 0.5f, transform.position.z), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)));
            SetBuilding(b);
        }
    }

    public void DestroyBuilding()
    {
        if (GetHexTile().GetBuilding() != null)
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
