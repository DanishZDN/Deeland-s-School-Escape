// using System.Collections;
// using UnityEngine;

// public class LightController : MonoBehaviour
// {
//     public float greenLightDuration = 5f;
//     public float redLightDuration = 3f;
//     public PlayerMovement player;
//     public Light arenaLight;
//     public Rigidbody playerRigidbody; // Reference to the player's Rigidbody for detecting movement

//     private bool isGreenLight = true;

//     void Start()
//     {
//         StartCoroutine(RedGreenLightCycle());
//     }

//     IEnumerator RedGreenLightCycle()
//     {
//         while (true)
//         {
//             // Green light phase
//             isGreenLight = true;
//             player.canMove = true;
//             ChangeLightColor(Color.green);
//             yield return new WaitForSeconds(greenLightDuration);

//             // Red light phase
//             isGreenLight = false;
//             player.canMove = false;
//             ChangeLightColor(Color.red);

//             // During the red light phase, check if the player is moving
//             yield return StartCoroutine(CheckPlayerMovementDuringRedLight());
//         }
//     }

//     IEnumerator CheckPlayerMovementDuringRedLight()
//     {
//         float timeRemaining = redLightDuration;

//         while (timeRemaining > 0)
//         {
//             if (playerRigidbody.velocity.magnitude > 0.1f) // Player is moving
//             {
//                 Debug.Log("Player moved during red light! You lose.");
//                 // Here you can trigger a lose condition (restart the game or show a failure screen)
//                 break;
//             }

//             timeRemaining -= Time.deltaTime;
//             yield return null; // Wait for the next frame
//         }
//     }

//     void ChangeLightColor(Color color)
//     {
//         if (arenaLight != null)
//         {
//             arenaLight.color = color;
//         }
//     }
// }
