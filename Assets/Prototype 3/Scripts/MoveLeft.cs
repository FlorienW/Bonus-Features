using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float moveSpeed = 30;
    private PlayerController playerControllerScript;
    public float leftBound = -15;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * (moveSpeed * Time.deltaTime));
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
