using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Transform startStage; // Reference to the Start Stage object

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player Variant"))
        {
            TeleportToStart(other.transform);
        }
    }

    private void TeleportToStart(Transform player)
    {
        player.position = startStage.position;
    }
}