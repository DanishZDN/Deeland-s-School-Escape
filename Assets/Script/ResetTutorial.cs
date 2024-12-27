using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetTutorial : MonoBehaviour
{
    bool reset = false;
    GameObject player;
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
        player.GetComponent<PlayerMotor>().enabled = false;
        player.transform.position = new Vector3(-10f, 0.5000002f, 27f);
        Invoke("ActivateMovement", 0.1f);
    }
}

void ActivateMovement(){
    player.GetComponent<InputManager>().enabled = true;
    player.GetComponent<PlayerMotor>().enabled = true;

}
}