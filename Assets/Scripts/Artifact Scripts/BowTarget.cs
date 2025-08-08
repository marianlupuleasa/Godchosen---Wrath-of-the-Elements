using UnityEngine;

public class BowTarget : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private Color bowGreen = new Color(0, 1, 0);
    private Color black = new Color(0, 0, 0);

    [SerializeField] Key key;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1) && GameManager.Instance.hammerUnlocked)
        {
            spriteRenderer.color = black;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && GameManager.Instance.bowUnlocked)
        {
            spriteRenderer.color = bowGreen;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && GameManager.Instance.wingsUnlocked)
        {
            spriteRenderer.color = black;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && GameManager.Instance.torchUnlocked)
        {
            spriteRenderer.color = black;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && GameManager.Instance.tridentUnlocked)
        {
            spriteRenderer.color = black;
        }

    }

    void OnDestroy()
    {
        key.GetComponent<SpriteRenderer>().enabled = true;
    }
}
