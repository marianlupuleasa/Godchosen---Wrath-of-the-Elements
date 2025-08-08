using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    bool wasPickedUp = false;
    public int collectType;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !wasPickedUp)
        {
            if(collectType == 0)
            {
                FindFirstObjectByType<IncreaseUI>().IncreaseCoin();
            }
            else if (collectType == 1)
            {
                FindFirstObjectByType<IncreaseUI>().IncreaseLore();
            }
            else if (collectType == 2)
            {
                FindFirstObjectByType<IncreaseUI>().IncreaseMemento();
            }
            else if (collectType == 3)
            {
                FindFirstObjectByType<IncreaseUI>().IncreaseAchievement();
            }
            Destroy(gameObject);
            wasPickedUp = true;
        }
    }
}