using UnityEngine;
using UnityEngine.Tilemaps;

public class Water: MonoBehaviour
{
    private TilemapCollider2D tilemapCollider2D;
    private PlayerTakeDamage playerTakeDamage;

    void Start()
    {
        tilemapCollider2D = GetComponent<TilemapCollider2D>();
        playerTakeDamage = FindObjectOfType<PlayerTakeDamage>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            tilemapCollider2D.isTrigger = false;
            playerTakeDamage.canTakeWaterDamage = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && GameManager.Instance.hammerUnlocked)
        {
            tilemapCollider2D.isTrigger = false;
            playerTakeDamage.canTakeWaterDamage = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && GameManager.Instance.bowUnlocked)
        {
            tilemapCollider2D.isTrigger = false;
            playerTakeDamage.canTakeWaterDamage = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && GameManager.Instance.wingsUnlocked)
        {
            tilemapCollider2D.isTrigger = false;
            playerTakeDamage.canTakeWaterDamage = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && GameManager.Instance.torchUnlocked)
        {
            tilemapCollider2D.isTrigger = false;
            playerTakeDamage.canTakeWaterDamage = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && GameManager.Instance.tridentUnlocked)
        {
            tilemapCollider2D.isTrigger = true;
            playerTakeDamage.canTakeWaterDamage = false;
        }

    }
}
