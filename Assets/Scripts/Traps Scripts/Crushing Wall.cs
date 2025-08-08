using UnityEngine;

public class CrushingWall : MonoBehaviour
{
    Vector2 startingPosition;
    bool canMove = true;
    public float wallSpeed;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if(transform.position.y < startingPosition.y - 3f)
        {
            canMove = false;
            transform.position = startingPosition;
            Invoke("ResetWall", 0.5f);
        }
        else if (canMove)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - wallSpeed * Time.deltaTime);
        }
    }

    void ResetWall()
    {
        canMove = true;
    }
}
