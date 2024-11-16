using UnityEngine;

public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has crossed the finish line! You win!");
            // Trigger win condition (e.g., show a win screen or restart the level)
        }
    }
}
