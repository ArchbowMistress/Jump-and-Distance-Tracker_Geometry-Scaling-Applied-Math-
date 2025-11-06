using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] public float movementSpeed = 50f;
    [SerializeField] public float jumpSpeed = 10f;
    [SerializeField] public float maxSpeed = 50f;
    private float gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3.0f;
    private float velocity;
    public Vector3 boxSize;
    public float castDistance;
    public LayerMask groundLayer;


    void FixedUpdate()
    {
        PlayerMovement();
        ManualGravity();

    }

    public bool isGrounded()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.TransformDirection(Vector3.up) * castDistance, boxSize);
    }

    void ManualGravity()
    {
        if (isGrounded() && velocity < 0.0f)
        {
            // Debug.Log("ITS A HIT");
            velocity = -1.0f;
            rb.AddForce(0, velocity * Time.deltaTime, 0, ForceMode.VelocityChange);
        }
        else
        {
            // Debug.Log("nah");
            velocity += gravity * gravityMultiplier * Time.deltaTime;

            rb.AddForce(0, velocity * Time.deltaTime, 0, ForceMode.VelocityChange);
        }
    }

    void PlayerMovement()
    {
        //Max Speed Cap
        //Debug.Log(rb.velocity.magnitude);
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        }
        



        if (Input.GetKey("w"))
        {
            // Debug.Log("Forward");
            rb.AddForce(0, 0, movementSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }
        //Right
        if (Input.GetKey("s"))
        {
            // Debug.Log("Backward");
            rb.AddForce(0, 0, -movementSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            // Debug.Log("Left");
            rb.AddForce(-movementSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        //Right
        if (Input.GetKey("d"))
        {
            // Debug.Log("Right");
            rb.AddForce(movementSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            // Debug.Log("Jump");
            rb.AddForce(0, jumpSpeed * Time.deltaTime, 0, ForceMode.VelocityChange);
        }
    }

    
}
