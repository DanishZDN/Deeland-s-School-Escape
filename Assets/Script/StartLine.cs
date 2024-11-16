using UnityEngine;

public class StartLine : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Race Started!");
            // You can implement logic for starting the race timer here.
        }
    }
}
