using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMotion : MonoBehaviour
{
    
    public TimeController timeController;

    void Update()
    {
        float sunAngle = (timeController.timeOfDay * 360.0f);
        float rad = sunAngle * Mathf.Deg2Rad + 3*Mathf.PI/2;
        float x = Mathf.Cos(rad)*5;
        float y = Mathf.Sin(rad)*5;
        float z = 0;

        transform.position = new Vector3(x, y, z);
    }

}