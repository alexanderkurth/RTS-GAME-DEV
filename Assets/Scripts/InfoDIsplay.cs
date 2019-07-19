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

         //   Material m_Material = hit.transform.gameObject.GetComponent<Renderer>().material;

            hextileName = hit.transform.gameObject.GetComponent<HexTile>().GetHexTileName();
            coordinates = hit.transform.gameObject.GetComponent<HexTile>().GetCoordinates().ToString();
            emptyness = hit.transform.gameObject.GetComponent<HexTile>().IsEmpty().ToString();
            infoText.text =  hextileName + "\n" + coordinates + "\n" + emptyness ;

         //   m_Material.color = Color.red;

        }
    }
}
