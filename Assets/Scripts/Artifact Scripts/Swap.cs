using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyAttack", 0.1f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Switch"))
        {
            GameObject switchObject = other.gameObject;
            if(switchObject.GetComponent<AirSwitch>().switchColor == switchObject.GetComponent<AirSwitch>().switchDeactivated)
            {
                AudioManager.instance.PlaySFX("Water Switch", 0.2f);
                switchObject.GetComponent<AirSwitch>().switchColor = switchObject.GetComponent<AirSwitch>().switchActivated;
                switchObject.GetComponent<AirSwitch>().tilemap.color = switchObject.GetComponent<AirSwitch>().switchColor;
                switchObject.GetComponent<AirSwitch>().waterStream.SetActive(true);
            }
            else if(switchObject.GetComponent<AirSwitch>().switchColor == switchObject.GetComponent<AirSwitch>().switchActivated)
            {
                AudioManager.instance.PlaySFX("Water Switch", 0.2f);
                switchObject.GetComponent<AirSwitch>().switchColor = switchObject.GetComponent<AirSwitch>().switchDeactivated;
                switchObject.GetComponent<AirSwitch>().tilemap.color = switchObject.GetComponent<AirSwitch>().switchColor;
                switchObject.GetComponent<AirSwitch>().waterStream.SetActive(false);
            }
        }

    }

    void DestroyAttack()
    {
        Destroy(gameObject);
    }
}
