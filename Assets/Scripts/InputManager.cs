using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //================================ Variables


    //================================ Methods

    public HexTile GetHexTileClicked()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            return hit.transform.gameObject.GetComponent<HexTile>();   
        else
            return null;
    }
}
