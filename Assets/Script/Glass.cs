using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    public bool isBreakable; // True for breakable, False for safe glass
    public Material breakableMaterial;
    public Material safeMaterial;

    private bool isSteppedOn = false;

    private void Start()
    {
        // Set the material based on whether the glass is breakable
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = isBreakable ? breakableMaterial : safeMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player Variant"))
        {
            StepOn();
        }
    }

    public void StepOn()
    {
        if (isBreakable && !isSteppedOn)
        {
            isSteppedOn = true;
            BreakGlass();
        }
    }

    private void BreakGlass()
    {
        // Disable the renderer and collider to simulate breaking glass
        Renderer renderer = GetComponent<Renderer>();
        Collider collider = GetComponent<Collider>();
        renderer.enabled = false;
        collider.enabled = false;
        // Add logic to handle player falling if needed
        // For example, you can call a method on the player to make them fall
    }
}