// using UnityEngine;
// using System.Collections;

// public class GameController : MonoBehaviour
// {
//     public PlayerMovement player;
//     public float greenLightTime = 5f;
//     public float redLightTime = 3f;

//     private bool isRedLight = false;

//     void Start()
//     {
//         StartCoroutine(StartGame());
//     }

//     IEnumerator StartGame()
//     {
//         while (true)
//         {
//             GreenLight();
//             yield return new WaitForSeconds(greenLightTime);

//             RedLight();
//             yield return new WaitForSeconds(redLightTime);
//         }
//     }

//     void GreenLight()
//     {
//         Debug.Log("Green Light! Go!");
//         isRedLight = false;
//         player.SetMovement(true);
//     }

//     void RedLight()
//     {
//         Debug.Log("Red Light! Stop!");
//         isRedLight = true;
//         player.SetMovement(false);
//     }

//     void Update()
//     {
//         if (isRedLight && player.GetComponent<Rigidbody>().velocity.magnitude > 0.1f)
//         {
//             Debug.Log("You Moved During Red Light! Game Over!");
//             // Implement logic for game over, like restarting or stopping the game.
//         }
//     }
// }
