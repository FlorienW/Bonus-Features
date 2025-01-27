using System.Collections;
using TMPro;
using UnityEngine;

namespace Prototype_3.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public GameObject player;
        public GameObject spawnManager;
        
        public PlayerController playerController;
        
        public TextMeshProUGUI scoreText;
        
        public float playerSpeed;
        public int score;
        
        

        private void Start()
        {
            StartCoroutine(GameStartBehaviour());
        }

        private IEnumerator GameStartBehaviour()
        {
            Debug.Log("Animation Running!");
            if (player.transform.position.x >= 0)
            {
                player.transform.position = new(0, player.transform.position.y, player.transform.position.z);
                StartTheGame();
            }
            
            player.transform.Translate(Vector3.right * (playerSpeed * Time.deltaTime), Space.World );
            yield return new WaitForSeconds(0.01f);
            StartCoroutine(GameStartBehaviour());
        }

        public void StartTheGame()
        {
            playerController.enabled = true;
            spawnManager.SetActive(true);
            StartCoroutine(ScoreBehaviour());
        }

        private IEnumerator ScoreBehaviour()
        {
            while (true)
            {
                if (!playerController.gameOver)
                {
                    score++;
                    if (Input.GetKey(KeyCode.D))
                    {
                        score++;
                    }
                    SyncTheScore();
                    yield return new WaitForSeconds(10f);
                }
                else
                {
                    break;
                }
            }
        }

        private void SyncTheScore()
        {
            scoreText.text = $"Score : {score}";
        }
        
        
    }
}
