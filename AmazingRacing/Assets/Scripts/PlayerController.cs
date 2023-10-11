using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Car Settings")]
    public float driftFactor = 1.0f;
    public float accelerationFactor = 30f;
    public float turnFactor = 4f;
    public float maxSpeed = 20f;

    float accelerationInput = 0;
    float steeringInput = 0;

    float rotationAngle = 0;

    float velocityVsUp = 0;

    Rigidbody2D carRigidbody2D;


    void Awake()
    {
        carRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        ApplyEngineForce();
        KillOrthogonalVelocity();
        ApplySteering();
    }
    void ApplyEngineForce()
    {
        //Calculate how much "foward" we are going in terms of the direction of our velocity
        velocityVsUp = Vector2.Dot(transform.up, carRigidbody2D.velocity);

        //Limit so we cannot go faster then the max speed in the "foward" direction
        if(velocityVsUp > maxSpeed && accelerationInput > 0)
            return;

        //Limit so we cannot go faster then %50 of max speed in the "reverse" direction
        if (velocityVsUp < -maxSpeed * 0.5f && accelerationInput < 0)
            return;

        //Limit so we cannot go faster in any direction while accelating
        if (carRigidbody2D.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0)
            return;

        //Apply drag if there is no accelerationInput so the car stops when the player lets go to accelator
        if (accelerationInput == 0)
            carRigidbody2D.drag = Mathf.Lerp(carRigidbody2D.drag, 7.0f, Time.fixedDeltaTime * 3);
        else
            carRigidbody2D.drag = 2;
        //Create a force for the engine
        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;

        //Apply force and pushes the car foward
        carRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);
    }
    void ApplySteering()
    {
        //Limit the cars ability to turn when moving slowly
        float minSpeedBeforeAllowTurningFactor = (carRigidbody2D.velocity.magnitude / 8);
        minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);

        //Update the rotation angle based on input
        rotationAngle -= steeringInput * turnFactor * minSpeedBeforeAllowTurningFactor;

        //Apply steering by rotating the car object
        carRigidbody2D.MoveRotation(rotationAngle);
    }
    void KillOrthogonalVelocity()
    {
        Vector2 fowardVelocity = transform.up * Vector2.Dot(carRigidbody2D.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(carRigidbody2D.velocity, transform.right);

        carRigidbody2D.velocity = fowardVelocity + rightVelocity * driftFactor;
    }
    float GetLateralVelocity()
    {
        //Returns how how fast the car is moving sideways
        return Vector2.Dot(transform.right, carRigidbody2D.velocity);
    }
    public bool IsTireScreeching(out float lateralVelocity, out bool isBraking)
    {
        lateralVelocity = GetLateralVelocity();
        isBraking = false;

        //Check if we are moving forward and if the player is hitting the brakes. In that case the tires should screech.
        if (accelerationInput < 0 && velocityVsUp > 0)
        {
            isBraking = true;
            return true;
        }
        //If we have a lot of side movement then the tires should be screeching
        if (Mathf.Abs(GetLateralVelocity()) > 3.0f)
            return true;

        return false;
    }
    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }
}
