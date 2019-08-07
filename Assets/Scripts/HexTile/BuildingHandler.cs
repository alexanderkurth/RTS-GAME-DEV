using UnityEngine;

public class BuildingHandler : MonoBehaviour
{
    //================================ Variables

    public static BuildingHandler ins;

    public Building simpleBuilding;
    public Building mine;
    public StockPile stockPile;

    public int maxStockpile;
    public int maxMine;
    public int maxSimpleBuilding;

    public int stockPileNumber;
    public int mineNumber;
    public int buildingNumber;

    public bool isMineMaxCountReached = false;
    public bool isStockpileMaxCountReached = false;
    public bool isSimpleBuildingMaxCountReached = false;

    //================================ Methods

    void Awake()
    {
        maxMine =3 ;
        maxStockpile = 1;
        maxSimpleBuilding = 2;

        ins = this;
    }

    void Sart()
    {

    }

    //[TODO] Refactor
    void Update()
    {
        if (maxMine == mineNumber)
            isMineMaxCountReached = true;
        else
            isMineMaxCountReached = false;

        if (maxSimpleBuilding == buildingNumber)
            isSimpleBuildingMaxCountReached = true;
        else
            isSimpleBuildingMaxCountReached = false;

        if (maxStockpile == stockPileNumber)
            isStockpileMaxCountReached = true;
        else
            isStockpileMaxCountReached = false;


    }

    //================================ Getters & Setters

    public Building GetSimpleBuilding() { buildingNumber++;  return simpleBuilding; }
    public Building GetMine() { mineNumber++; return mine; }
    public Building GetStockPile() { stockPileNumber++; return stockPile; }

}
