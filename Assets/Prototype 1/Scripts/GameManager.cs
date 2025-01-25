using System.Collections;
using UnityEngine;

namespace Prototype_1.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public KeyCode Player1LeftKey = KeyCode.A;
        public KeyCode Player1RightKey = KeyCode.D;
        public KeyCode Player2LeftKey = KeyCode.LeftArrow;
        public KeyCode Player2RightKey = KeyCode.RightArrow;

        public float speed = 40f;
        
        public static GameManager instance;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
        
            instance = this;
        }

        private void Start()
        {
            StartCoroutine(SpeedAcceleration());
        }

        private IEnumerator SpeedAcceleration()
        {
            yield return new WaitForSeconds(5f);
            speed *= 1.1f;
            StartCoroutine(SpeedAcceleration());
        }
        
    }
}
