using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    public Vector3 spawnPosition = new Vector3(25, 0, 0);
    public float startDelay = 2f;
    public float repeatDelay = 2f;
    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatDelay);
    }

    void SpawnObstacle()
    {
        Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);
    }

}
