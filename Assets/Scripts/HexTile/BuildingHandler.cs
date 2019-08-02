using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{
    public static BuildingHandler ins;
    public Building simpleBuilding;
    public Building mine;

    void Awake()
    {
        ins = this;
    }

    void Update()
    {
 
    }


    public Building GetSimpleBuilding() { return simpleBuilding; }
    public Building GetMine() { return mine; }


}
