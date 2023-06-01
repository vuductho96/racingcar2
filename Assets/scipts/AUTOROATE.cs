using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUTOROATE : MonoBehaviour
{
    public Transform[] carMeshes; // Array of car mesh objects

    private void FixedUpdate()
    {
        transform.Rotate(0, 0.5f, 0); // Rotate the cylinder

        // Rotate each car mesh along with the cylinder
        foreach (Transform carMesh in carMeshes)
        {
            carMesh.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }
    }
}
