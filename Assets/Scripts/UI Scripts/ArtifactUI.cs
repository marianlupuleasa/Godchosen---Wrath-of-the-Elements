using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArtifactUI : MonoBehaviour
{
    [SerializeField] Image artifactBackground;
    [SerializeField] Image artifactEquipped;

    private Color locked = new Color(0.66f, .66f, 0.66f);
    private Color equipped = new Color(0, 0, 0);
    private Color unequipped = new Color(1, 1, 1);

    private Color hammerOrange = new Color(1, 0.5f, 0);
    private Color bowGreen = new Color(0.66f, 1, 0);
    private Color wingsYellow = new Color(1, 1, 0.33f);
    private Color torchRed = new Color(1, 0.33f, 0);
    private Color tridentBlue = new Color(0.33f, 0.66f, 1);

    void Update()
    {
        if (GameManager.Instance.hammerUnlocked)
        {
            if (name == "Hammer")
            {
                artifactBackground.color = hammerOrange;
            }
        }
        if (GameManager.Instance.bowUnlocked)
        {
            if (name == "Bow")
            {
                artifactBackground.color = bowGreen;
            }
        }
        if (GameManager.Instance.wingsUnlocked)
        {
            if (name == "Wings")
            {
                artifactBackground.color = wingsYellow;
            }
        }
        if (GameManager.Instance.torchUnlocked)
        {
            if (name == "Torch")
            {
                artifactBackground.color = torchRed;
            }
        }
        if (GameManager.Instance.tridentUnlocked)
        {
            if (name == "Trident")
            {
                artifactBackground.color = tridentBlue;
            }
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            artifactEquipped.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && GameManager.Instance.hammerUnlocked)
        {
            if (name == "Hammer")
            {
                artifactEquipped.gameObject.SetActive(true);
            }
            else
            {
                artifactEquipped.gameObject.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && GameManager.Instance.bowUnlocked)
        {
            if (name == "Bow")
            {
                artifactEquipped.gameObject.SetActive(true);
            }
            else
            {
                artifactEquipped.gameObject.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && GameManager.Instance.wingsUnlocked)
        {
            if (name == "Wings")
            {
                artifactEquipped.gameObject.SetActive(true);
            }
            else
            {
                artifactEquipped.gameObject.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && GameManager.Instance.torchUnlocked)
        {
            if (name == "Torch")
            {
                artifactEquipped.gameObject.SetActive(true);
            }
            else
            {
                artifactEquipped.gameObject.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && GameManager.Instance.tridentUnlocked)
        {
            if (name == "Trident")
            {
                artifactEquipped.gameObject.SetActive(true);
            }
            else
            {
                artifactEquipped.gameObject.SetActive(false);
            }
        }
    }
}