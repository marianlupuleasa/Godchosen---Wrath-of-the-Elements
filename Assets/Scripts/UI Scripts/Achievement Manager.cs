using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AchievementManager : MonoBehaviour
{

    public GameObject achievementUI;
    [SerializeField] public TextMeshProUGUI achievement;

    void Update()
    {
        if (GameManager.Instance.mementoCounter == 18 && GameManager.Instance.canMemento)
        {
            FindFirstObjectByType<IncreaseUI>().IncreaseAchievement();
            StartAchievement("You have collected all the mementos in the game!");
            GameManager.Instance.canMemento = false;
        }
        if (GameManager.Instance.loreCounter == 13 && GameManager.Instance.canLore)
        {
            FindFirstObjectByType<IncreaseUI>().IncreaseAchievement();
            StartAchievement("You have collected all the lore in the game!");
            GameManager.Instance.canLore = false;
        }
        if (GameManager.Instance.coinCounter == 99 && GameManager.Instance.canCoin)
        {
            FindFirstObjectByType<IncreaseUI>().IncreaseAchievement();
            StartAchievement("You have collected all the coins in the game!");
            GameManager.Instance.canCoin = false;
        }
        if (GameManager.Instance.hammerUnlocked && 
            GameManager.Instance.bowUnlocked &&
            GameManager.Instance.wingsUnlocked &&
            GameManager.Instance.torchUnlocked &&
            GameManager.Instance.tridentUnlocked && GameManager.Instance.canArtifact)
        {
            FindFirstObjectByType<IncreaseUI>().IncreaseAchievement();
            StartAchievement("You have unlocked all the artifacts!");
            GameManager.Instance.canArtifact = false;
        }
        if (GameManager.Instance.earthGem &&
            GameManager.Instance.natureGem &&
            GameManager.Instance.airGem &&
            GameManager.Instance.fireGem &&
            GameManager.Instance.waterGem && GameManager.Instance.canGem)
        {
            FindFirstObjectByType<IncreaseUI>().IncreaseAchievement();
            StartAchievement("You have unlocked all the gems!");
            GameManager.Instance.canGem = false;
        }

    }

    public void StartAchievement(string line)
    {
        achievementUI.SetActive(true);
        achievement.text = line;
        Invoke("EndAchievement", 3f);
    }

    public void EndAchievement()
    {
        achievementUI.SetActive(false);
    }
}
