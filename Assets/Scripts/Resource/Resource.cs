using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource 
{

    private string name;
    private string type;
    private float extractionTime;

    public Resource(string name, string type, float extractionTime)
    {
        this.name = name;
        this.type = type;
        this.extractionTime = extractionTime;
    }

    public float GetExtractionTime() { return extractionTime; }
}
