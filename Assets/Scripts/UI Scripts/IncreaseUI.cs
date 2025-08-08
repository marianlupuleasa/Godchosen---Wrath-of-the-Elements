using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IncreaseUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI loreText;
    [SerializeField] TextMeshProUGUI mementoText;
    [SerializeField] TextMeshProUGUI achievementText;

    void Start()
    {
        scoreText.text = GameManager.Instance.coinCounter.ToString("D2");
        loreText.text = GameManager.Instance.loreCounter.ToString("D2");
        mementoText.text = GameManager.Instance.mementoCounter.ToString("D2");
        achievementText.text = GameManager.Instance.achievementCounter.ToString("D2");
    }

    public void IncreaseCoin()
    {
        GameManager.Instance.coinCounter++;
        scoreText.text = GameManager.Instance.coinCounter.ToString("D2");
    }

    public void IncreaseLore()
    {
        GameManager.Instance.loreCounter++;
        loreText.text = GameManager.Instance.loreCounter.ToString("D2");
    }

    public void IncreaseMemento()
    {
        GameManager.Instance.mementoCounter++;
        mementoText.text = GameManager.Instance.mementoCounter.ToString("D2");
    }

    public void IncreaseAchievement()
    {
        GameManager.Instance.achievementCounter++;
        achievementText.text = GameManager.Instance.achievementCounter.ToString("D2");
    }
}