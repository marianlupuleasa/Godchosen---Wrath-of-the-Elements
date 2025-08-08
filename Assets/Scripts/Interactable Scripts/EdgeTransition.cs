using UnityEngine;

public class EdgeTransition : MonoBehaviour
{
    [SerializeField] private float valueX;
    [SerializeField] private float valueY;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(valueX != 0)
            {
                collision.transform.position = new Vector2(valueX, collision.transform.position.y);
            }
            if(valueY != 0)
            {
                collision.transform.position = new Vector2(collision.transform.position.x, valueY);
            }
        }
    }
}
