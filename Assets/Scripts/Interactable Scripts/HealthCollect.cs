using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollect : MonoBehaviour
{
    bool wasPickedUp = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !wasPickedUp)
        {
            FindFirstObjectByType<HealthUI>().IncreaseHealth();
            Destroy(gameObject);
            wasPickedUp = true;
        }
    }
}