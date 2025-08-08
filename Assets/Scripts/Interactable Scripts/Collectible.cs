using UnityEngine;

[RequireComponent(typeof(UniqueID))]
public class Collectible : MonoBehaviour
{
    private UniqueID uniqueID;

    void Start()
    {
        uniqueID = GetComponent<UniqueID>();

        if (CollectibleTracker.Instance.IsCollected(uniqueID.ID))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CollectibleTracker.Instance.MarkCollected(uniqueID.ID);
            Destroy(gameObject);
        }
    }
}