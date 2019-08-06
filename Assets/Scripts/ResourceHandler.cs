using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHandler : MonoBehaviour
{

    public StockPile stockPile;
    public static ResourceHandler ins;
    public int quantite;

    void Start()
    {
        ins = this;
    }

    void Update()
    {
    //    Debug.Log(stockPile.quantity);
    }
}
