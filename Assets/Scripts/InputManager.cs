using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //================================ Variables

    public HexTile selectedHextile;
    public HexTileManager hexTileManager;

    //================================ Methods

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hexTileManager = GetHexTileClicked().transform.gameObject.GetComponent<HexTileManager>();

            if(!hexTileManager.IsSelected() && selectedHextile == null)
            {
                selectedHextile = GetHexTileClicked();
                selectedHextile.SetSelected(true);
                hexTileManager.SetMaterialColor(Color.red);
            }
            else if(selectedHextile == GetHexTileClicked())
            {
                selectedHextile.SetSelected(false);
                selectedHextile = null;
                hexTileManager.SetMaterialColor(Color.white);
                hexTileManager = null;
            }
            else if(!hexTileManager.IsSelected() && selectedHextile != null)
            {
                selectedHextile.SetSelected(false);
                selectedHextile.gameObject.GetComponent<HexTileManager>().SetMaterialColor(Color.white);

                selectedHextile = GetHexTileClicked();
                selectedHextile.SetSelected(true);
                hexTileManager.SetMaterialColor(Color.red);
            }

        }
    }

    public HexTile GetHexTileClicked()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            return hit.transform.gameObject.GetComponent<HexTile>();   
        else
            return null;
    }

    public void SetSelectedHextile(HexTile hextile) { this.selectedHextile = hextile ; }

    public HexTileManager GetHexTileManager() { return this.hexTileManager; }
}
