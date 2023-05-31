using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float maxSpeed = 20f;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private WheelCollider[] wheelColliders;
    [SerializeField] private Transform[] wheelTransforms;

    private float moveInput;
    private float rotationInput;

    private float currentSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");

        // Calculate acceleration based on input and current speed
        float accelerationAmount = moveInput * acceleration * Time.fixedDeltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed + accelerationAmount, -maxSpeed, maxSpeed);

        // Move the player
        rb.velocity = transform.forward * currentSpeed;

        // Rotate the player
        float rotationAmount = rotationInput * rotationSpeed * Time.fixedDeltaTime;
        Quaternion rotation = Quaternion.Euler(0f, rotationAmount, 0f);
        rb.MoveRotation(rb.rotation * rotation);

        // Rotate the wheels
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            wheelColliders[i].motorTorque = currentSpeed;

            Quaternion wheelRotation;
            Vector3 wheelPosition;
            wheelColliders[i].GetWorldPose(out wheelPosition, out wheelRotation);

            // Apply wheel rotation based on the car's rotation
            wheelRotation *= Quaternion.Euler(0f, rotationAmount, 0f);
            wheelTransforms[i].rotation = wheelRotation;
        }
    }

}
    



