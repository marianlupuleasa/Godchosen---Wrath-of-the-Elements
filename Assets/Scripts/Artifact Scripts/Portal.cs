using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour
{
    [SerializeField] string destinationName;
    [SerializeField] Vector2 destinationPosition;
    public DialogueManager dialogueManager;
    bool canShowDialogue = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && destinationName != "Chamber")
        {
            GameObject player = other.gameObject;
            StartCoroutine(CallWithDelay(2f, player));
            GameManager.Instance.returnToTemplePosition = destinationPosition;
            player.GetComponent<PlayerMovement>().destinationName = destinationName;
            GameManager.Instance.lastCheckpointPosition = destinationPosition;
        }

        if(destinationName == "Chamber" && canShowDialogue)
        {
            if(GameManager.Instance.earthGem && GameManager.Instance.waterGem && GameManager.Instance.airGem && GameManager.Instance.fireGem && GameManager.Instance.natureGem)
            {
                GameObject player = other.gameObject;
                StartCoroutine(CallWithDelay(2f, player));
                GameManager.Instance.returnToTemplePosition = destinationPosition;
                player.GetComponent<PlayerMovement>().destinationName = destinationName;
                GameManager.Instance.lastCheckpointPosition = new Vector2(0, 0);
                string[] dialogueText = new string[] { "By the elements combined, the path to the treasure is open! Venture forth and bring back the lost Lightning Bolt, young hero." };
                dialogueManager.StartDialogue(dialogueText, "Zeus");
                Time.timeScale = 0f;
            }
            else
            {
                string[] dialogueText = new string[] { "The doors of the Chamber are locked until you retrieve every single elemental gem!" };
                dialogueManager.StartDialogue(dialogueText, "Zeus");
                Time.timeScale = 0f;
            }
            canShowDialogue = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (destinationName == "Chamber")
        {
            canShowDialogue = true;
        }
    }

    IEnumerator CallWithDelay(float delay, GameObject player)
    {
        yield return new WaitForSeconds(delay);
        canTeleport(player);
    }

    void canTeleport(GameObject player)
    {
        player.GetComponent<PlayerMovement>().canTeleport = true;
    }
}
