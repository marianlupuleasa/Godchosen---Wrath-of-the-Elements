using UnityEngine;
using TMPro;

public class Achievement : MonoBehaviour
{
    public string achievementText;
    bool canTriggerAchievement = true;

    public AchievementManager achievementManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canTriggerAchievement)
        {
            canTriggerAchievement = false;
            achievementManager.StartAchievement(achievementText);
            AudioManager.instance.PlaySFX("Achievement", 0.5f);
        }
    }
}
