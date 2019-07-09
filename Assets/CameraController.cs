using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float movementSpeed = 0.1f;
    public float rotationSpeed = 4f;
    public float smoothness = 0.85f;

    Vector3 targetPosition;

    public Quaternion targetRotation;
    public float targetRotationY;
    public float targetRotationX;

    public Vector2 panLimit;
    public float panBorderThickness = 10.0f;
    public float minY = 5.0f;
    public float maxY = 30.0f;
    public int scrollSpeed = 10;

    void Start()
    {
        targetPosition = transform.position;
        targetRotation = transform.rotation;
        targetRotationY = transform.localRotation.eulerAngles.y;
        targetRotationX = transform.localRotation.eulerAngles.x;
    }

    void Update()
    {
        Vector3 targetPosition = transform.position;


        if (Input.GetKey(KeyCode.Z) || Input.mousePosition.y >= Screen.height - panBorderThickness)
            targetPosition += transform.forward * movementSpeed;


        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
            targetPosition -= transform.forward * movementSpeed;

        if (Input.GetKey(KeyCode.Q) || Input.mousePosition.x <= panBorderThickness)
            targetPosition -= transform.right * movementSpeed;

        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
            targetPosition += transform.right * movementSpeed;

        if (Input.GetKey(KeyCode.A) )
            targetPosition -= transform.up * movementSpeed;

        if (Input.GetKey(KeyCode.E) )
            targetPosition += transform.up * movementSpeed;

        if (Input.GetAxis("Mouse ScrollWheel") > 0.0f && targetPosition.y > minY)
            targetPosition -= transform.up * movementSpeed * 100.0f;

        if (Input.GetAxis("Mouse ScrollWheel") < 0.0f && targetPosition.y < maxY)
            targetPosition += transform.up * movementSpeed * 100.0f;

        transform.position = Vector3.Lerp(transform.position, targetPosition, (1.0f - smoothness));
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, (1.0f - smoothness));
    }
}