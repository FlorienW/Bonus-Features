using System.Collections;
using UnityEngine;

namespace Prototype_1.Scripts
{
    public class Spawner : MonoBehaviour
    {
        public GameObject[] prefabs;
        private float _spawnerCooldownTime;
        private float _spawnerStartingCooldownTime = 1.5f * 40;


        private void Start()
        {
            Instantiate(PickRandomPrefab(), PickRandomPositionForPlayer1(), Quaternion.identity);
            Instantiate(PickRandomPrefab(), PickRandomPositionForPlayer2(), Quaternion.identity);
            _spawnerCooldownTime = _spawnerStartingCooldownTime / GameManager.instance.speed;
            StartCoroutine(SpawnerCoroutine());
            StartCoroutine(SyncTheSpawnerCooldownTime());
        }

        private GameObject PickRandomPrefab()
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            return prefabs[randomIndex];
        }

        private Vector3 PickRandomPositionForPlayer1()
        {
            float randomXPosition = Random.Range(-20f, -8f);
            Vector3 randomPos = new Vector3(randomXPosition, 0, 180);
            return randomPos;
        }
        
        private Vector3 PickRandomPositionForPlayer2()
        {
            float randomXPosition = Random.Range(8f, 20f);
            Vector3 randomPos = new Vector3(randomXPosition, 0, 180);
            return randomPos;
        }

        private IEnumerator SpawnerCoroutine()
        {
            yield return new WaitForSeconds(_spawnerCooldownTime);
            Instantiate(PickRandomPrefab(), PickRandomPositionForPlayer1(), Quaternion.identity);
            Instantiate(PickRandomPrefab(), PickRandomPositionForPlayer2(), Quaternion.identity);
            StartCoroutine(SpawnerCoroutine());
        }

        private IEnumerator SyncTheSpawnerCooldownTime()
        {
            yield return new WaitForSeconds(4f);
            _spawnerCooldownTime = _spawnerStartingCooldownTime / GameManager.instance.speed;
            StartCoroutine(SyncTheSpawnerCooldownTime());
        }
    }
}
