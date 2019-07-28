using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMotion : MonoBehaviour
{
    
    public TimeController timeController;

    void Update()
    {
        float sunAngle = timeController.timeOfDay * 360.0f;
        float rad = sunAngle * Mathf.Deg2Rad;
        float x = Mathf.Cos(rad);
        float y = Mathf.Sin(rad);
        float z = 0;

        transform.position = new Vector3(x, y, z);
    }

}