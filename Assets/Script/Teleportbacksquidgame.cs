using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportbacksquidgame : MonoBehaviour
{
        GameObject player;
        bool reset = false;
    void OnTriggerEnter(Collider other)
{
    Debug.Log("Trigger entered by: " + other.name); // Log the object name
    if (other.CompareTag("Player"))
    {
        Debug.Log("Player detected in trigger.");
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Debug.Log("Rigidbody found. Resetting velocity.");
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        reset = true;
        player = other.gameObject;
        player.GetComponent<InputManager>().enabled = false;
        player.transform.position = new Vector3(3.715407f, 33.5f, -78.4f);
        Invoke("ActivateMovement", 0.2f);
    }
}

void ActivateMovement(){
    player.GetComponent<InputManager>().enabled = true;
}
}