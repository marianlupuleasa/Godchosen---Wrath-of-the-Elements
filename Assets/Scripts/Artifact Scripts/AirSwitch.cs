using UnityEngine;
using UnityEngine.Tilemaps;

public class AirSwitch : MonoBehaviour
{
    [SerializeField] public Tilemap tilemap;
    public GameObject waterStream;

    public Color switchDeactivated = new Color(0, 0, 0);
    public Color switchActivated = new Color(0, 0.33f, 1);
    public Color switchColor;

    void Start()
    {
        switchColor = switchActivated;

    }
}