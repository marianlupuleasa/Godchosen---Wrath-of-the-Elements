using UnityEngine;

public class Artifact : MonoBehaviour
{
    public int artifactNumber;
    bool wasPickedUp = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !wasPickedUp)
        {
            GameManager.Instance.UnlockArtifact(artifactNumber);
            Destroy(gameObject);
            wasPickedUp = true;
        }
    }
}
