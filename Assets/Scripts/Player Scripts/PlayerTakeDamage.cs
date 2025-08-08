    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    bool tookDamage = false;
    Rigidbody2D myRigidbody2D;
    public PlayerMovement playerMovement;
    public bool canTakeDamageArrow = true;
    public bool canTakeWaterDamage = true;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Flame Wall") || (collision.gameObject.CompareTag("Water") && canTakeWaterDamage) || (collision.gameObject.CompareTag("Enemy Arrow") && canTakeDamageArrow))  && !tookDamage)
        {
            FindFirstObjectByType<HealthUI>().DecreaseHealth();
            tookDamage = true;
            AudioManager.instance.PlaySFX("Death", 0.5f);
            Invoke("ResetDamage", 0.2f);

            if (GameManager.Instance.health == 0)
            {
                FindFirstObjectByType<GameMenuNavigation>().Lose();
            }
            else
            {
                Debug.Log("Player took damage, resetting position to last saved position.");
                transform.position = new Vector2(GameManager.Instance.lastCheckpointPosition.x, GameManager.Instance.lastCheckpointPosition.y);
            }
        }

       if(collision.gameObject.CompareTag("Enemy Arrow") && !canTakeDamageArrow)
       {
            AudioManager.instance.PlaySFX("Arrow Destroy", 0.5f);
       }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Water") && canTakeWaterDamage && !tookDamage)
        {
            FindFirstObjectByType<HealthUI>().DecreaseHealth();
            tookDamage = true;
            AudioManager.instance.PlaySFX("Death", 0.5f);
            Invoke("ResetDamage", 0.2f);
            if (GameManager.Instance.health == 0)
            {
                FindFirstObjectByType<GameMenuNavigation>().Lose();
            }
            else
            {
                Debug.Log("Player took damage, resetting position to last saved position.");
                transform.position = new Vector2(GameManager.Instance.lastCheckpointPosition.x, GameManager.Instance.lastCheckpointPosition.y);
            }
        }
    }

    void ResetDamage()
    {
        tookDamage = false;
    }
}