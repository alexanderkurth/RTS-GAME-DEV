using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //================================ Variables

    private float movementSpeed = 0.85f;
    private float rotationSpeed = 4f;
    private float smoothness = 0.85f;

    private Vector2 panLimit;
    private float panBorderThickness = 10.0f;
    private float minY = 5.0f;
    private float maxY = 30.0f;

    private Quaternion targetRotation;
    private float targetRotationY;
    private float targetRotationX;

    //================================ Methods

    void Start()
    {
        targetRotation = transform.rotation;
        targetRotationY = transform.localRotation.eulerAngles.y;
        targetRotationX = transform.localRotation.eulerAngles.x;
    }

    void Update()
    {
        Vector3 targetPosition = transform.position;


        if (Input.GetKey(KeyCode.Z) || Input.mousePosition.y >= Screen.height - panBorderThickness)
            targetPosition.z += movementSpeed;


        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
            targetPosition.z -= movementSpeed;

        if (Input.GetKey(KeyCode.Q) || Input.mousePosition.x <= panBorderThickness)
            targetPosition.x -= movementSpeed;

        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
            targetPosition.x += movementSpeed;

        if (Input.GetKey(KeyCode.A) )
            targetPosition.y -= movementSpeed;

        if (Input.GetKey(KeyCode.E) )
            targetPosition.y += movementSpeed;

        if (Input.GetAxis("Mouse ScrollWheel") > 0.0f && targetPosition.y > minY)
            targetPosition.y -= 1 ;

        if (Input.GetAxis("Mouse ScrollWheel") < 0.0f && targetPosition.y < maxY)
            targetPosition.y += 1;

        if (Input.GetMouseButton(2))
        {
            Cursor.visible = false;
            targetRotationY += Input.GetAxis("Mouse X") * rotationSpeed;
            targetRotationX -= Input.GetAxis("Mouse Y") * rotationSpeed;
            targetRotation = Quaternion.Euler(targetRotationX, targetRotationY, 0.0f);
        }
        else
            Cursor.visible = true;

        transform.position = Vector3.Lerp(transform.position, targetPosition, (1.0f - smoothness));
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, (1.0f - smoothness));
    }
}