using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;

    int currentLineIndex = 0;
    bool isDialogueActive = false;
    public string[] dialogueText;

    [SerializeField] public TextMeshProUGUI dialogue;
    [SerializeField] public TextMeshProUGUI speakerName;

    public GameObject victoryScreen;

    private void Start()
    {
        victoryScreen.SetActive(false);
    }

    void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.F))
        {
            ShowNextLine();
        }
    }

    public void StartDialogue(string[] lines, string speaker)
    {
        dialogueText = lines;
        currentLineIndex = 0;
        isDialogueActive = true;
        dialogueUI.SetActive(true);
        dialogue.text = dialogueText[currentLineIndex];
        speakerName.text = speaker;
    }

    void ShowNextLine()
    {
        currentLineIndex++;
        if (currentLineIndex < dialogueText.Length)
        {
            if (dialogueText[currentLineIndex] == "END")
            {
                victoryScreen.SetActive(true);
                EndDialogue();
            }
            dialogue.text = dialogueText[currentLineIndex];
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        dialogueUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
