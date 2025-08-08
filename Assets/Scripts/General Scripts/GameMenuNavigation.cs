using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuNavigation : MonoBehaviour
{
    [SerializeField] public GameObject defeatScreen;
    [SerializeField] public GameObject pauseScreen;
    public Vector2 templePosition;

    bool isPaused = false;

    void Start()
    {
        defeatScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Lose()
    {
        Time.timeScale = 0f;
        GameManager.Instance.isAlive = false;
        Invoke("Reset", 0.1f);
    }

    public void Pause()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
            defeatScreen.SetActive(false);
            pauseScreen.SetActive(false);
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
            isPaused = true;
        }
    }

    public void Continue()
    {
        if (GameManager.Instance.lastGameScene == "")
        {
            GameManager.Instance.lastGameScene = "Temple";
            GameManager.Instance.health = GameManager.Instance.maxHealth;
            GameManager.Instance.lastCheckpointPosition = new Vector2(0, 0);
        }
        SceneManager.LoadScene(GameManager.Instance.lastGameScene);
        GameManager.Instance.pressedContinue = true;
    }

    public void ReturnToTemple()
    {
        GameManager.Instance.returnToTemplePosition = templePosition;
        GameManager.Instance.lastCheckpointPosition = templePosition;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Temple");
    }


    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Reset()
    {
        defeatScreen.SetActive(true);
        GameManager.Instance.ResetGame();
    }
}