using UnityEngine;

public class BrazzierLight : MonoBehaviour
{
    public SpriteMask spriteMask;
    public GameObject light;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteMask = GetComponent<SpriteMask>();
        spriteRenderer = light.GetComponent<SpriteRenderer>();
        spriteMask.enabled = false;
        spriteRenderer.enabled = false;
    }
}
