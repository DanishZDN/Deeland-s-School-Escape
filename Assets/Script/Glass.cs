using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameNamespace
{
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

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player") && !isSteppedOn)
            {
                isSteppedOn = true;
                if (isBreakable)
                {
                    StartCoroutine(BreakGlass());
                }
            }
        }

        private IEnumerator BreakGlass()
        {
            yield return new WaitForSeconds(0.5f); // Delay before the glass breaks
            // Play glass breaking animation or effect (optional)
            Destroy(gameObject); // Remove the tile
        }
    }
}