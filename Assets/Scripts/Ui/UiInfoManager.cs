﻿using UnityEngine;

public class UiInfoManager : MonoBehaviour
{
    //================================ Variables

    private string infoText;
    private HexTileManager hextileManager;

    public InputManager inputManager;

    //================================ Methods

    void Update()
    {
        hextileManager = inputManager.GetHexTileManager();

        if (inputManager.GetHexTileManager() != null)
        {
            GetInformations();
        }
        else
            infoText = null;
    }

    void GetInformations()//check hextile manager from InputManager
    {
            string hextileName;
            string coordinates;
            string emptyness;
        Building b;

            hextileName = hextileManager.GetHexTile().GetHexTileName();
            coordinates = hextileManager.GetHexTile().GetCoordinates().ToString();
            emptyness = hextileManager.GetHexTile().IsEmpty().ToString();
            b = hextileManager.GetHexTile().GetBuilding();
            infoText = hextileName + "\n" + coordinates + "\n" + emptyness + b;
        
    }

    //================================ Getters & Setters
    public string GetInfoText() { return this.infoText; }

}