using UnityEngine;

public class Gem : MonoBehaviour
{
    public int gemNumber;
    bool wasPickedUp = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !wasPickedUp)
        {
            GameManager.Instance.UnlockGem(gemNumber);
            Destroy(gameObject);
            wasPickedUp = true;
        }
    }
}
