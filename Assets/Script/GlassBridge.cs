using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBridge : MonoBehaviour
{
    public Transform[] levels; // Levels of the bridge, where each level has two glass tiles (Cube 1 and Cube 2)
    public Material safeMaterial; // Material for the safe glass
    public Material breakMaterial; // Material for the breakable glass
    public float breakDelay = 0.5f; // Delay before the glass breaks

    private bool[,] glassProperties; // Store information about which glass is safe or breakable
    private Transform player;
    private int currentLevel;
    private PlayerMotor playerMotor;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        playerMotor = player.GetComponent<PlayerMotor>();
        currentLevel = 0;
        InitializeGlassProperties();
    }

    void Update()
    {
        CheckPlayerMovement();
    }

    void InitializeGlassProperties()
    {
        // Initialize properties randomly for each level
        glassProperties = new bool[levels.Length, 2];
        for (int i = 0; i < levels.Length; i++)
        {
            int safeTile = Random.Range(0, 2); // Randomly choose which tile is safe
            for (int j = 0; j < 2; j++)
            {
                glassProperties[i, j] = (j == safeTile);
                MeshRenderer renderer = levels[i].GetChild(j).GetComponent<MeshRenderer>();
                renderer.material = safeTile == j ? safeMaterial : breakMaterial;
            }
        }
    }

    void CheckPlayerMovement()
    {
        if (currentLevel >= levels.Length) return; // Player has reached the end
        
        // Check if player is above one of the current level's tiles
        Transform level = levels[currentLevel];
        for (int i = 0; i < 2; i++)
        {
            Transform tile = level.GetChild(i);
            if (Vector3.Distance(player.position, tile.position) < 1.0f) // Assuming small distance indicates the player is on the tile
            {
                if (!glassProperties[currentLevel, i])
                {
                    StartCoroutine(BreakTile(tile));
                }
                else
                {
                    currentLevel++; // Move to next level
                }
                break;
            }
        }
    }

    IEnumerator BreakTile(Transform tile)
    {
        yield return new WaitForSeconds(breakDelay); // Add delay before breaking
        tile.gameObject.SetActive(false); // Deactivate the glass to simulate breaking
        playerMotor.Fall(); // Call the Fall method from PlayerMotor to simulate falling
    }
}