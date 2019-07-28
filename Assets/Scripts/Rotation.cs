using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    float timeCounter = 0;
    public float x, y, z;
    public Light sun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);

        timeCounter += Time.deltaTime / 4;

        x = Mathf.Cos(timeCounter);
        y = Mathf.Sin(timeCounter);
        z = 0;

        transform.position = new Vector3(x*10, y*10, z);

        sun.transform.Rotate(new Vector3(x ,0,0));
    }
}
