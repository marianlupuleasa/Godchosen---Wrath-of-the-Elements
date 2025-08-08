using UnityEngine;

public class EnemyArrow : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.rigidbody != null && other.rigidbody.tag == "Player")
        {
            Destroy(gameObject);
        }
        else if (other.rigidbody != null && other.rigidbody.tag == "Terrain")
        {
            Destroy(gameObject);
        }
    }
}
