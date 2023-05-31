using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderAutorotate : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 10f; // Adjust the speed of rotation as desired

    // Update is called once per frame
    void Update()
    {
        // Rotate the cylinder around its Y-axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
