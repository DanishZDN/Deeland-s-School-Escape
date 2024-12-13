using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportbacksquidgame : MonoBehaviour
{
    //teleport the player
    private Vector3 teleportLocation = new Vector3(3.715407f, 33.5f, -78.36988f);

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
           
            other.transform.position = teleportLocation;
        }
    }
}
