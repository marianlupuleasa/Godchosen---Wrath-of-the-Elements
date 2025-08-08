using UnityEngine;
using UnityEngine.SceneManagement;

public class LightningBolt : MonoBehaviour
{
    [SerializeField] public GameObject victoryScreen;

    private void Start()
    {
        victoryScreen.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("LoadVictoryScreen", 5f);
        }
    }

    void LoadVictoryScreen()
    {
        victoryScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
