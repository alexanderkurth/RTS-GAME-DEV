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
    [SerializeField] private int quantite;
    [SerializeField] private bool isWorking;

    //================================ Methods

    IEnumerator ExtractResource()
    {
        while(isWorking)
        {
            yield return new WaitForSeconds(producedResource.GetExtractionTime());
            quantite += production ;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(quantite);
    }

    
}
