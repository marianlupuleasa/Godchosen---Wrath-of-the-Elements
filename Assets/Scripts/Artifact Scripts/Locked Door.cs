using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    [SerializeField] GameObject key;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (key.GetComponent<Key>().keyCollected)
            {
                Destroy(gameObject);
                AudioManager.instance.PlaySFX("Door", 0.5f);
            }
        }
    }
}
