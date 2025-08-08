using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public string dialogueSpeakerName;
    public string[] dialogueText;
    bool canTriggerDialogue = true;

    public DialogueManager dialogueManager;

    void Update()
    {
        if(!GameManager.Instance.isAlive)
        {
            string[] dialogueTextDead = new string[] {
                "You thought those pomegranates could keep me away forever, huh? Feel the cold embrace of death, fallen hero…"
            };
            dialogueManager.StartDialogue(dialogueTextDead, "Hades");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canTriggerDialogue)
        {
            canTriggerDialogue = false;
            dialogueManager.StartDialogue(dialogueText, dialogueSpeakerName);
            Time.timeScale = 0f;
        }
    }
}
