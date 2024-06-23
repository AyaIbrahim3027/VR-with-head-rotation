using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroController : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;
    private Quaternion rot;
    private GameObject cameraContainer;


    void Start()
    {
        // Create a container for the camera and make the camera a child of the container
        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);

        // Check and enable gyroscope
        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Debug.Log("Gyroscope supported");
            gyro = Input.gyro;
            gyro.enabled = true;
            // Adjust initial rotation
            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rot = new Quaternion(0, 0, 1, 0);
            return true;
        }
        Debug.Log("Gyroscope not supported");
        return false;
    }

    void Update()
    {
        if (gyroEnabled)
        {
            Debug.Log("Gyroscope attitude: " + gyro.attitude);
            transform.localRotation = gyro.attitude * rot;
        }
    }
}
