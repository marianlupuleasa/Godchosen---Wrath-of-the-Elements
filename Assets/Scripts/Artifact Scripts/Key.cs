using UnityEngine;

public class Key : MonoBehaviour
{
    public bool keyCollected = false;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            keyCollected = true;
            spriteRenderer.enabled = false;
        }
    }
}
