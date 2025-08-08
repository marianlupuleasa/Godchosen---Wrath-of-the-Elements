using UnityEngine;

public class ShootingStatue : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    [SerializeField] float shootInterval = 1f;
    [SerializeField] float arrowSpeed = 5f;
    [SerializeField] float arrowLifetime = 5f;
    [SerializeField] float arrowDirection = -1;
    [SerializeField] float arrowRotation;

    void Start()
    {
        arrowRotation = arrowDirection;
        InvokeRepeating("ShootArrow", 0f, shootInterval);
    }

    void ShootArrow()
    {
        Vector3 arrowPosition = transform.position + new Vector3(0, 0.18f, 0);
        GameObject arrowInstance = Instantiate(arrow, arrowPosition, Quaternion.identity);
        arrowInstance.transform.localScale = new Vector3(0.5f * transform.localScale.x, transform.localScale.x, arrowInstance.transform.localScale.z);
        arrowInstance.transform.localPosition = new Vector3(arrowInstance.transform.localPosition.x, arrowInstance.transform.localPosition.y + 0.5f, 0f);

        arrowInstance.transform.rotation = Quaternion.Euler(0f, 0f, arrowRotation);
        Rigidbody2D rb = arrowInstance.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(arrowDirection * arrowSpeed, 0f);
        Destroy(arrowInstance, arrowLifetime);
    }


}
