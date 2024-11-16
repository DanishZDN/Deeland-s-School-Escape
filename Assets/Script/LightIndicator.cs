using UnityEngine;

public class LightIndicator : MonoBehaviour
{
    public Material redLightMaterial;
    public Material greenLightMaterial;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void SetGreenLight()
    {
        rend.material = greenLightMaterial;
    }

    public void SetRedLight()
    {
        rend.material = redLightMaterial;
    }
}
