using System.Collections;
using UnityEngine;

namespace Prototype_1.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public float speed = 40f;

        public string Player1Name;
        public string Player2Name;

        public GameObject Spawner;
        public Spawner SpawnerScript;
        
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

        public void ChangePlayerName(string newName, int playerNumber1or2)
        {
            if (playerNumber1or2 == 1)
            {
                if (newName == string.Empty)
                {
                    Player1Name = "Player1";
                    return;
                }
                Player1Name = newName;
                return;
            }
            if (newName == string.Empty)
            {
                Player2Name = "player2";
                return;
            }
            Player2Name = newName;
        }

        public void StartGame()
        {
            speed = 40f;
            Spawner.SetActive(true);
            SpawnerScript.StartAtBeginning();
        }

        public void EndGame(int failedPlayerID1or2)
        {
            speed = 0f;
            Spawner.SetActive(false);
            UIManager.instance.ActivateEndGameUI();
            UIManager.instance.DeclareTheWinnerPlayer(failedPlayerID1or2 == 1 ? 2 : 1);
            DestroyAllObstacles();
        }

        private void DestroyAllObstacles()
        {
            GameObject[] allObstacles = GameObject.FindGameObjectsWithTag("Obstacles");
            foreach (GameObject obstacle in allObstacles)
            {
                Destroy(obstacle);
            }
        }
        
    }
}
