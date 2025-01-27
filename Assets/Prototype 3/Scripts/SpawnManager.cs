using UnityEngine;

namespace Prototype_3.Scripts
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject[] obstacles;
        public Vector3 spawnPosition = new(30, 0, 0);
        public float startDelay = 0f;
        public float repeatDelay = 1.8f;
        void Start()
        {
            InvokeRepeating(nameof(SpawnRandomObstacle), startDelay, repeatDelay);
        }

        void SpawnRandomObstacle()
        {
            int index = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[index], spawnPosition, obstacles[index].transform.rotation);
        }

    }
}
