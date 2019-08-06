using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockPile : Building
{

    [SerializeField] private Resource[] stackableResources;
    [SerializeField] private int maxQuantity;
    public int quantity;
    void Start()
    {
        
    }

    void Update()
    {
        quantity = ResourceHandler.ins.quantite;
        Debug.Log(quantity);
    }
}
