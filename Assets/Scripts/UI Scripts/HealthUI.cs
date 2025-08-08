using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI healthText;

    void Start()
    {
        healthText.text = GameManager.Instance.health.ToString("D2");
    }

    public void IncreaseHealth()
    {
        GameManager.Instance.health++;
        healthText.text = GameManager.Instance.health.ToString("D2");
    }

    public void DecreaseHealth()
    {
        GameManager.Instance.health--;
        healthText.text = GameManager.Instance.health.ToString("D2");
    }
}