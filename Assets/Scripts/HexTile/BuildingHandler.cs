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
        if (maxMine == 0)
            isMineMaxCountReached = true;
        else
            isMineMaxCountReached = false;

        if (maxSimpleBuilding == 0)
            isSimpleBuildingMaxCountReached = true;
        else
            isSimpleBuildingMaxCountReached = false;

        if (maxStockpile == 0)
            isStockpileMaxCountReached = true;
        else
            isStockpileMaxCountReached = false;


    }

    //================================ Getters & Setters

    public Building GetSimpleBuilding() { maxSimpleBuilding--;  return simpleBuilding; }
    public Building GetMine() { maxMine--; return mine; }
    public Building GetStockPile() { maxStockpile--; return stockPile; }

}
