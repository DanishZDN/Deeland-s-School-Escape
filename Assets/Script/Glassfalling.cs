using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassFalling : MonoBehaviour
{
    GameObject player;
    bool reset = false;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.isKinematic = true; // Initially, make it kinematic to prevent it from falling
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.name); // Log the object name
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected in trigger.");
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                Debug.Log("Player chose the wrong route.");
                playerRb.velocity = Vector3.zero;
                playerRb.angularVelocity = Vector3.zero;
            }
            reset = true;
            player = other.gameObject;
            player.GetComponent<InputManager>().enabled = false;
            Debug.Log("Player has chosen the wrong path");
            Invoke("ActivateMovement", 0.2f);
            Invoke("StartFalling", 0.2f); // Start falling after a short delay
        }
    }

    void ActivateMovement()
    {
        player.GetComponent<InputManager>().enabled = true;
    }

    void StartFalling()
    {
        rb.isKinematic = false; // Make the Rigidbody non-kinematic to enable physics
        rb.AddForce(Vector3.down * 10, ForceMode.Acceleration); // Apply a downward force
    }
}