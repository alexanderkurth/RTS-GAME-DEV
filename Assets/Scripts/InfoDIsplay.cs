using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour
{
    //================================ Variables

    //UI Text
    public Text infoText;

    //Hextile's name
    private string hextileName;
    private string coordinates;
    private string emptyness;

    public HexTile selectedHextile;



    //================================ Methods

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickOnTile();
        }
    }

    void ClickOnTile()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {

            Material m_Material = hit.transform.gameObject.GetComponent<Renderer>().material;

            hextileName = hit.transform.gameObject.GetComponent<HexTile>().GetHexTileName();
            coordinates = hit.transform.gameObject.GetComponent<HexTile>().GetCoordinates().ToString();
            emptyness = hit.transform.gameObject.GetComponent<HexTile>().IsEmpty().ToString();
            infoText.text =  hextileName + "\n" + coordinates + "\n" + emptyness ;

            if ( !IsHextileSelected(hit.transform.gameObject.GetComponent<HexTile>()) && selectedHextile == null )
            {
                selectedHextile = hit.transform.gameObject.GetComponent<HexTile>();
                selectedHextile.SetSelected(true);
                m_Material.color = Color.red;

            }
            else if(selectedHextile == hit.transform.gameObject.GetComponent<HexTile>())
            {
                selectedHextile.SetSelected(false);
                selectedHextile = null;
                m_Material.color = Color.white;
            }
            else if(!IsHextileSelected(hit.transform.gameObject.GetComponent<HexTile>()) && selectedHextile != null)
            {
                selectedHextile.SetSelected(false);
                Material m_Material2 = selectedHextile.GetComponent<Renderer>().material;
                m_Material2.color = Color.white;

                selectedHextile = hit.transform.gameObject.GetComponent<HexTile>();
                selectedHextile.SetSelected(true);
                m_Material.color = Color.red;
            }



        }
    }

    private bool IsHextileSelected(HexTile hextile)
    {
        return hextile.IsSelected();
    }
}
