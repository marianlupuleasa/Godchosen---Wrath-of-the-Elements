using UnityEngine;
using UnityEngine.Tilemaps;

public class ClimbableWall : MonoBehaviour
{
    private Tilemap tilemap;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Collider2D>().isTrigger = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && GameManager.Instance.hammerUnlocked)
        {
            GetComponent<Collider2D>().isTrigger = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && GameManager.Instance.bowUnlocked)
        {
            GetComponent<Collider2D>().isTrigger = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && GameManager.Instance.wingsUnlocked)
        {
            GetComponent<Collider2D>().isTrigger = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && GameManager.Instance.torchUnlocked)
        {
            GetComponent<Collider2D>().isTrigger = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && GameManager.Instance.tridentUnlocked)
        {
            GetComponent<Collider2D>().isTrigger = false;
        }

    }
}
