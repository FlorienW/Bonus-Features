using UnityEngine;

namespace Prototype_3.Scripts
{
    public class MoveLeft : MonoBehaviour
    {
        public float moveSpeed = 30;
        private PlayerController _playerControllerScript;
        public float leftBound = -15;

        void Start()
        {
            _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        }

        void Update()
        {
            if (_playerControllerScript.gameOver == false)
            {
                transform.Translate(Vector3.left * (moveSpeed * Time.deltaTime), Space.World);
            }

            if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
            }

            moveSpeed = _playerControllerScript.speed;

        }
    }
}
