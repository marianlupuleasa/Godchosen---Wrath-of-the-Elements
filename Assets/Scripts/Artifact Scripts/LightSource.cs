using UnityEngine;

public class LightSource : MonoBehaviour
{
    public SpriteMask spriteMask;
    public GameObject light;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteMask = GetComponent<SpriteMask>();
        spriteRenderer = light.GetComponent<SpriteRenderer>();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            spriteMask.enabled = false;
            spriteRenderer.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && GameManager.Instance.hammerUnlocked)
        {
            spriteMask.enabled = false;
            spriteRenderer.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && GameManager.Instance.bowUnlocked)
        {
            spriteMask.enabled = false;
            spriteRenderer.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && GameManager.Instance.wingsUnlocked)
        {
            spriteMask.enabled = false;
            spriteRenderer.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && GameManager.Instance.torchUnlocked)
        {
            spriteMask.enabled = true;
            spriteRenderer.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && GameManager.Instance.tridentUnlocked)
        {
            spriteMask.enabled = false;
            spriteRenderer.enabled = false;
        }

    }
}
