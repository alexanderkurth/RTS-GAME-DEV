using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMotion : MonoBehaviour
{
    
    [SerializeField] private TimeController timeController;
    [SerializeField] private GameObject sun;
    [SerializeField] private GameObject moon;



    void Update()
    {
        SunOrbit();
        MoonOrbit();
    }

    public void SunOrbit()
    {
        float sunAngle = (timeController.timeOfDay * 360.0f);
        float rad = ConvertToRadient(sunAngle) + 3 * Mathf.PI / 2;
        float x = Mathf.Cos(rad) * 50;
        float y = Mathf.Sin(rad) * 50;
        float z = 0;

        sun.transform.position = new Vector3(x, y, z);
    }

    public void MoonOrbit()
    {
        float moonAngle = (timeController.timeOfDay * 360.0f);
        float rad = ConvertToRadient(moonAngle) + Mathf.PI/2;
        float x = Mathf.Cos(rad) * 50;
        float y = Mathf.Sin(rad) * 50;
        float z = 0;

        moon.transform.position = new Vector3(x, y, z);
    }

    private float ConvertToRadient(float angle)
    {
        return angle * Mathf.Deg2Rad;
    }

}