using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour
{

    private Quaternion initialRotation;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialRotation = transform.rotation;
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Detect rotation
        Quaternion currentRotation = transform.rotation;
        Vector3 rotationDifference = currentRotation.eulerAngles - initialRotation.eulerAngles;

        if (Mathf.Abs(rotationDifference.x) > 30 || Mathf.Abs(rotationDifference.y) > 30)
        {
            Debug.Log("Head rotation detected");
        }

        // Detect shaking (translate)
        Vector3 currentPosition = transform.position;
        Vector3 positionDifference = currentPosition - initialPosition;

        if (positionDifference.magnitude > 0.1f)
        {
            Debug.Log("Head shake detected");
        }

        // Reset for next frame
        initialRotation = currentRotation;
        initialPosition = currentPosition;
    }
}
