using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 10f;
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
        float accelerationAmount = moveInput * speed * Time.fixedDeltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed + accelerationAmount, -speed, speed);

        // Move the player
        rb.velocity = transform.forward * currentSpeed;

        // Rotate the player
        float rotationAmount = rotationInput * rotationSpeed * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(0f, rotationAmount, 0f);
        rb.MoveRotation(rb.rotation * deltaRotation);

        // Rotate the wheels
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            wheelColliders[i].motorTorque = currentSpeed;

            // Set the steering angle of front wheel colliders
            if (i == 0 || i == 1) // Assuming the front wheels are at index 0 and 1
            {
                float steeringAngle = rotationInput * 45f; // Adjust the steering angle
                wheelColliders[i].steerAngle = steeringAngle;
            }
            else
            {
                wheelColliders[i].steerAngle = 0f; // Reset the steering angle for non-front wheels
            }

            Quaternion wheelRotation;
            Vector3 wheelPosition;
            wheelColliders[i].GetWorldPose(out wheelPosition, out wheelRotation);

            wheelTransforms[i].rotation = wheelRotation;
        }
    }

}
    



