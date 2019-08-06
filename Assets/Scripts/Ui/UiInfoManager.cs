﻿using UnityEngine;

public class UiInfoManager : MonoBehaviour
{
    //================================ Variables

    [SerializeField] private string infoText;
    [SerializeField] private string goldResource;

    [SerializeField] private string mineNumber;
    [SerializeField] private string stockPileNumber;
    [SerializeField] private string buildingNumber;


    [SerializeField] private HexTileManager hextileManager;

    [SerializeField] private InputManager inputManager;

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

    public void GetInformations()
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

    public string GetGoldInStockPile() { return StockPile.quantity.ToString(); }
    public string GetStockPileNumber() { return BuildingHandler.ins.maxStockpile.ToString(); }
    public string GetInfoText() { return this.infoText; }
    public string GetGoldReourceText() { return this.goldResource; }

}