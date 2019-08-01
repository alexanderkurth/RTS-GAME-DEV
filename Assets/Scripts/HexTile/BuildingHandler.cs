using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{
    public static BuildingHandler ins;
    void Awake()
    {
        ins = this;
    }

    public Building simpleBuilding;

    public Building GetSimpleBuilding() { return simpleBuilding; }


}
