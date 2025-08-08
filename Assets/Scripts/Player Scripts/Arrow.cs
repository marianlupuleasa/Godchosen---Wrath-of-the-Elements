using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D myRigidbody2D;
    [SerializeField] float arrowSpeed;
    float arrowXSpeed;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        arrowXSpeed = this.transform.localScale.x * arrowSpeed;

    }

    void Update()
    {
        myRigidbody2D.linearVelocity = new Vector2(arrowXSpeed, 0f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.rigidbody.tag == "Bow Target")
        {
            Destroy(other.gameObject);
            AudioManager.instance.PlaySFX("Container", 0.2f);
        }

        Destroy(gameObject);

    }
}