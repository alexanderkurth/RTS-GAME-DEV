using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class UiInfoManager : MonoBehaviour
{
    //================================ Variables

    [SerializeField] private string infoText;

    [SerializeField] private int mineNumber;
    [SerializeField] private int stockPileNumber;
    [SerializeField] private int buildingNumber;


    [SerializeField] private HexTileManager hextileManager;

    [SerializeField] private InputManager inputManager;

    public Dictionary<string,string> labels = new Dictionary<string, string>();

    //================================ Methods

    void Awake()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("Assets/label.xml");

        foreach (XmlNode node in doc.DocumentElement.ChildNodes)
        {
            labels.Add(node.Attributes["name"].InnerText, node.InnerText);
        }
    }

    void Update()
    {
        hextileManager = inputManager.GetHexTileManager();

        if (inputManager.GetHexTileManager() != null)
        {
            GetInformations();
        }
        else
            infoText = null;

        mineNumber = BuildingHandler.ins.mineNumber;
        stockPileNumber = BuildingHandler.ins.stockPileNumber;
        buildingNumber = BuildingHandler.ins.buildingNumber;
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
    public string GetInfoText() { return this.infoText; }

    public int GetMineNumber() { return mineNumber; }
    public int GetBuildingNumber() { return buildingNumber; }
    public int GetStockPileNumber() { return stockPileNumber; }

}