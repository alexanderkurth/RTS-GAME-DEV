using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Building
{
    //================================ Variables

    [SerializeField] private int production;
    [SerializeField] private int workers;
    [SerializeField] private Resource producedResource;
    [SerializeField] private Resource resourceNeeded;
    [SerializeField] private bool isWorking;


    //================================ Methods

    private void Awake()
    {
        producedResource = new Resource("gold", "mineral", 1.0f);
        production = 1;
        workers = 1;
        isWorking = true;
    }
    void Start()
    {
        StartCoroutine(ExtractResource());
    }

    IEnumerator ExtractResource()
    {
        while(isWorking)
        {
            ResourceHandler.ins.quantite += production * workers;

            yield return new WaitForSeconds(producedResource.GetExtractionTime());
        }
    }

    void Update()
    {
        if (ResourceHandler.ins.quantite >= StockPile.maxQuantity)
        {
            isWorking = false;
            StopCoroutine(ExtractResource());

        }
        else
        {
            isWorking = true;
        }
    }

    
}
