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
    private bool isEmpty;

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
            hextileName = hit.transform.name;
            infoText.text = hextileName;
        }
    }
}
