using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    float timeCounter = 0;
    public float x, y, z;
    public TimeController timeController;

    public float speed = 1;
    float width;
    float height;

    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
    }

    void Update()
    {
        float timeOfDay = timeController.timeOfDay;
        float sunAngle = timeOfDay * 360.0f;

        timeCounter += Time.deltaTime * speed;

        x = Mathf.Cos(timeCounter);
        y = Mathf.Sin(timeCounter);
        z = 0;

        transform.position = new Vector3(x, y, z);

    }
}
