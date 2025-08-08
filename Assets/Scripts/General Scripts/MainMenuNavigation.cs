using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuNavigation : MonoBehaviour
{
    [SerializeField] public GameObject mainMenuScreen;
    [SerializeField] public GameObject playScreen;
    [SerializeField] public GameObject partSelectionScreen;
    [SerializeField] public GameObject levelSelectionScreen;
    [SerializeField] public GameObject optionsScreen;

    [SerializeField] public Button heroButton;
    [SerializeField] public Button legendButton;
    [SerializeField] public Button godButton;
    [SerializeField] public Button hadesButton;

    Color selectedColor = new Color(0.721f, 0.157f, 0f);
    Color defaultColor = new Color(0.957f, 0.482f, 0f);
    Image heroImage;
    Image legendImage;
    Image godImage;
    Image hadesImage;

    void Start()
    {
        mainMenuScreen.SetActive(true);
        heroImage = heroButton.GetComponent<Image>();
        legendImage = legendButton.GetComponent<Image>();
        godImage = godButton.GetComponent<Image>();
        hadesImage = hadesButton.GetComponent<Image>();
        if (GameManager.Instance.difficulty == 1)
        {
            heroImage.color = selectedColor;
        }
        else if (GameManager.Instance.difficulty == 2)
        {
            legendImage.color = selectedColor;
        }
        else if (GameManager.Instance.difficulty == 3)
        {
            godImage.color = selectedColor;
        }
        else if (GameManager.Instance.difficulty == 4)
        {
            hadesImage.color = selectedColor;
        }

    }

    void Update()
    {
        
    }

    public void Play()
    {
        mainMenuScreen.SetActive(false);
        playScreen.SetActive(true);
    }

    public void NewGame()
    {
        playScreen.SetActive(false);
        SceneManager.LoadScene("Temple");
        GameManager.Instance.health = GameManager.Instance.maxHealth;
        GameManager.Instance.ResetGame();
    }

    public void Continue()
    {
        playScreen.SetActive(false);
        if(GameManager.Instance.lastGameScene == "")
        {
            GameManager.Instance.lastGameScene = "Temple";
            GameManager.Instance.health = GameManager.Instance.maxHealth;
            GameManager.Instance.lastCheckpointPosition = new Vector2(0, 0);
        }
        SceneManager.LoadScene(GameManager.Instance.lastGameScene);
        GameManager.Instance.pressedContinue = true;
    }

    public void PartSelection()
    {
        playScreen.SetActive(false);
        partSelectionScreen.SetActive(true);
    }

    public void Part1()
    {
        partSelectionScreen.SetActive(false);
        SceneManager.LoadScene("Temple");
        GameManager.Instance.lastGameScene = "Temple";
        GameManager.Instance.health = GameManager.Instance.maxHealth;
        GameManager.Instance.ResetGame();
    }

    public void Part2()
    {
        partSelectionScreen.SetActive(false);
        levelSelectionScreen.SetActive(true);
    }

    public void Earth()
    {
        levelSelectionScreen.SetActive(false);
        SceneManager.LoadScene("Earth");
        GameManager.Instance.lastGameScene = "Earth";
        GameManager.Instance.health = GameManager.Instance.maxHealth;
        GameManager.Instance.ResetGame();
    }

    public void Fire()
    {
        levelSelectionScreen.SetActive(false);
        SceneManager.LoadScene("Fire");
        GameManager.Instance.lastGameScene = "Fire";
        GameManager.Instance.health = GameManager.Instance.maxHealth;
        GameManager.Instance.ResetGame();
    }

    public void Water()
    {
        levelSelectionScreen.SetActive(false);
        SceneManager.LoadScene("Water");
        GameManager.Instance.lastGameScene = "Water";
        GameManager.Instance.health = GameManager.Instance.maxHealth;
        GameManager.Instance.ResetGame();
    }

    public void Air()
    {
        levelSelectionScreen.SetActive(false);
        SceneManager.LoadScene("Air");
        GameManager.Instance.lastGameScene = "Air";
        GameManager.Instance.health = GameManager.Instance.maxHealth;
        GameManager.Instance.ResetGame();
    }

    public void Nature()
    {
        partSelectionScreen.SetActive(false);
        SceneManager.LoadScene("Nature");
        GameManager.Instance.lastGameScene = "Nature";
        GameManager.Instance.health = GameManager.Instance.maxHealth;
        GameManager.Instance.ResetGame();
    }

    public void Part2Return()
    {
        levelSelectionScreen.SetActive(false);
        partSelectionScreen.SetActive(true);
    }

    public void Part3()
    {
        partSelectionScreen.SetActive(false);
        SceneManager.LoadScene("Chamber");
        GameManager.Instance.lastGameScene = "Chamber";
        GameManager.Instance.health = GameManager.Instance.maxHealth;
        GameManager.Instance.ResetGame();
        GameManager.Instance.hammerUnlocked = true;
        GameManager.Instance.bowUnlocked = true;
        GameManager.Instance.wingsUnlocked = true;
        GameManager.Instance.torchUnlocked = true;
        GameManager.Instance.tridentUnlocked = true;
        GameManager.Instance.earthGem = true;
        GameManager.Instance.natureGem = true;
        GameManager.Instance.airGem = true;
        GameManager.Instance.fireGem = true;
        GameManager.Instance.waterGem = true;
    }

    public void Options()
    {
        mainMenuScreen.SetActive(false);
        optionsScreen.SetActive(true);
    }

    public void Easy()
    {
        GameManager.Instance.maxHealth = 10;
        heroImage.color = selectedColor;
        legendImage.color = defaultColor;
        godImage.color = defaultColor;
        hadesImage.color = defaultColor;
        GameManager.Instance.difficulty = 1;
    }

    public void Medium()
    {
        GameManager.Instance.maxHealth = 5;
        heroImage.color = defaultColor;
        legendImage.color = selectedColor;
        godImage.color = defaultColor;
        hadesImage.color = defaultColor;
        GameManager.Instance.difficulty = 2;
    }

    public void Hard()
    {
        GameManager.Instance.maxHealth = 3;
        heroImage.color = defaultColor;
        legendImage.color = defaultColor;
        godImage.color = selectedColor;
        hadesImage.color = defaultColor;
        GameManager.Instance.difficulty = 3;
    }

    public void Extreme()
    {
        GameManager.Instance.maxHealth = 1;
        heroImage.color = defaultColor;
        legendImage.color = defaultColor;
        godImage.color = defaultColor;
        hadesImage.color = selectedColor;
        GameManager.Instance.difficulty = 4;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        mainMenuScreen.SetActive(true);
        optionsScreen.SetActive(false);
        partSelectionScreen.SetActive(false);
    }
}
