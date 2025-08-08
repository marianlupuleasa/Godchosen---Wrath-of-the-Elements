using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int maxHealth; 
    public int health;
    public bool isAlive = true;
    public Vector2 returnToTemplePosition;
    public Vector2 lastCheckpointPosition;
    public bool hammerUnlocked = false;
    public bool bowUnlocked = false;
    public bool wingsUnlocked = false;
    public bool torchUnlocked = false;
    public bool tridentUnlocked = false;
    public bool earthGem = false;
    public bool natureGem = false;
    public bool airGem = false;
    public bool fireGem = false;
    public bool waterGem = false;
    public int mementoCounter = 0;
    public int loreCounter = 0;
    public int achievementCounter = 0;
    public int coinCounter = 0;
    public int gemCounter = 0;
    public int artifactCounter = 0;
    public string lastGameScene;
    public CollectibleTracker collectibleTracker;
    public bool pressedContinue = false;
    public int difficulty = 1;
    public bool canMemento = true;
    public bool canLore = true;
    public bool canCoin = true;
    public bool canArtifact = true;
    public bool canGem = true;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(transform.root.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        AudioManager.instance.PlayMusic("Background");

    }

    public void UnlockArtifact(int artifactNumber)
    {
        switch (artifactNumber)
        {
            case 1:
                hammerUnlocked = true;
                break;
            case 2:
                bowUnlocked = true;
                break;
            case 3:
                wingsUnlocked = true;
                break;
            case 4:
                torchUnlocked = true;
                break;
            case 5:
                tridentUnlocked = true;
                break;
            default:
                Debug.LogWarning("Unknown artifact number: " + artifactNumber);
                break;
        }
    }

    public void UnlockGem(int gemNumber)
    {
        switch (gemNumber)
        {
            case 1:
                earthGem = true;
                break;
            case 2:
                natureGem = true;
                break;
            case 3:
                airGem = true;
                break;
            case 4:
                fireGem = true;
                break;
            case 5:
                waterGem = true;
                break;
            default:
                Debug.LogWarning("Unknown gem number: " + gemNumber);
                break;
        }
    }

    public void ResetGame()
    {
        health = maxHealth;
        returnToTemplePosition = Vector2.zero;
        isAlive = true;
        hammerUnlocked = false;
        bowUnlocked = false;
        wingsUnlocked = false;
        torchUnlocked = false;
        tridentUnlocked = false;
        earthGem = false;
        natureGem = false;
        airGem = false;
        fireGem = false;
        waterGem = false;
        mementoCounter = 0;
        loreCounter = 0;
        achievementCounter = 0;
        coinCounter = 0;
        gemCounter = 0;
        artifactCounter = 0;
        lastGameScene = string.Empty;
        collectibleTracker.ClearCollected();
        canMemento = true;
        canLore = true;
        canCoin = true;
        canArtifact = true;
        canGem = true;
    }
}

