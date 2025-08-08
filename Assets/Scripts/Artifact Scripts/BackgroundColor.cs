using UnityEngine;
using UnityEngine.Tilemaps;

public class BackgroundColor : MonoBehaviour
{
    private Tilemap tilemap;

    private Color defaultColor = new Color(0.7f, 0.7f, 0.7f);
    private Color hammerOrange = new Color(1, 0.5f, 0);
    private Color bowGreen = new Color(0.66f, 1, 0);
    private Color wingsYellow = new Color(1, 1, 0.33f);
    private Color torchRed = new Color(1, 0.33f, 0);
    private Color tridentBlue = new Color(0.33f, 0.66f, 1);

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            tilemap.color = defaultColor;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && GameManager.Instance.hammerUnlocked)
        {
            tilemap.color = hammerOrange;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && GameManager.Instance.bowUnlocked)
        {
            tilemap.color = bowGreen;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && GameManager.Instance.wingsUnlocked)
        {
            tilemap.color = wingsYellow;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && GameManager.Instance.torchUnlocked)
        {
            tilemap.color = torchRed;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && GameManager.Instance.tridentUnlocked)
        {
            tilemap.color = tridentBlue;
        }

    }
}
