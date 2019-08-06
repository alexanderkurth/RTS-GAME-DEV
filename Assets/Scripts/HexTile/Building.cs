using UnityEngine;

public class Building : MonoBehaviour
{
    //================================ Variables

    [SerializeField] protected bool inUse;



    //================================ Methods

    void Awake()
    {
    }



    public void DestroyBuilding()
    {
        if (this is Mine)
            BuildingHandler.ins.maxMine++;
        if (this is StockPile)
            BuildingHandler.ins.maxStockpile++;
        if (this is Building)
            BuildingHandler.ins.maxSimpleBuilding++;

        Destroy(gameObject);
    }

    //================================ Getters & Setters







}
