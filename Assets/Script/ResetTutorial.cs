using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetTutorial : MonoBehaviour
{
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
        other.gameObject.transform.position = new Vector3(-0.1383868f, 0.5000002f, 0.862f);
        Debug.Log("Player teleported.");
    }
}
}