using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour
{
    //================================ Variables

    //UI Text
    public Text infoText;

    public HexTile selectedHextile;

    public HexTileManager hextileManager;

    //================================ Methods

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickOnTile();
        }
    }

    void ClickOnTile()//[TODO] Refactor -- class Input manager + HextileManager + UiManager 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            hextileManager = hit.transform.gameObject.GetComponent<HexTileManager>();
            string hextileName;
            string coordinates;
            string emptyness;

            hextileName = hextileManager.GetHexTile().GetHexTileName();
            coordinates = hextileManager.GetHexTile().GetCoordinates().ToString();
            emptyness = hextileManager.GetHexTile().IsEmpty().ToString();
            infoText.text = hextileName + "\n" + coordinates + "\n" + emptyness;

            if (!hextileManager.IsSelected() && selectedHextile == null)
            {
                selectedHextile = hit.transform.gameObject.GetComponent<HexTile>();
                selectedHextile.SetSelected(true);
                hextileManager.SetMaterialColor(Color.red);

            }
            else if (selectedHextile == hit.transform.gameObject.GetComponent<HexTile>())
            {
                selectedHextile.SetSelected(false);
                selectedHextile = null;
                hextileManager.SetMaterialColor(Color.white);
            }
            else if (!hextileManager.IsSelected() && selectedHextile != null)
            {
                selectedHextile.SetSelected(false);
                selectedHextile.gameObject.GetComponent<HexTileManager>().SetMaterialColor(Color.white);

                selectedHextile = hit.transform.gameObject.GetComponent<HexTile>();
                selectedHextile.SetSelected(true);
                hextileManager.SetMaterialColor(Color.red);
            }
        }
    }
}
