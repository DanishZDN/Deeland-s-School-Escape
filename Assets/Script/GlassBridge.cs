using UnityEngine;

public class GlassBridge : MonoBehaviour
{
    private PlayerMotor playerMotor;
    private Transform player;
    private int currentLevel;
    private bool[,] glassProperties;
    public Transform bridge; // Reference to the Bridge object
    public Transform[] levels; // Reference to the Level objects
    public float levelHeight = 1.0f; // Height of each level

    void Start()
    {
        player = GameObject.FindWithTag("PlayerVariant").transform;
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
                Glass glass = levels[i].GetChild(j).GetComponent<Glass>();
                glass.isBreakable = !glassProperties[i, j];
            }
        }
    }

    void CheckPlayerMovement()
    {
        // Check if the player is on a new level
        int playerLevel = Mathf.FloorToInt(player.position.z / levelHeight);
        if (playerLevel != currentLevel && playerLevel >= 0 && playerLevel < levels.Length)
        {
            currentLevel = playerLevel;
            CheckGlassBreak();
        }
    }

    void CheckGlassBreak()
    {
        // Check which glass the player is standing on
        int glassIndex = (player.position.x < 0) ? 0 : 1;
        if (currentLevel >= 0 && currentLevel < levels.Length && glassIndex >= 0 && glassIndex < 2)
        {
            Glass glass = levels[currentLevel].GetChild(glassIndex).GetComponent<Glass>();
            glass.StepOn();
            if (glass.isBreakable)
            {
                // Add logic to handle player falling
                playerMotor.Fall();
            }
        }
    }
}