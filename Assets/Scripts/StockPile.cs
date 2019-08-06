using UnityEngine;

public class StockPile : Building
{

    [SerializeField] private Resource[] stackableResources;
    [SerializeField] public static int maxQuantity = 3;
    public static int quantity;
    void Start()
    {
        
    }

    void Update()
    {
        quantity = ResourceHandler.ins.quantite;
    }
}
