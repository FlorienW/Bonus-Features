using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    private float _minSpeed = 12;
    private float _maxSpeed = 16;
    private float _maxTorque = 8;
    private float _xRange = 4;
    private float _ySpawnPosition = -6;
    
    private Rigidbody targetRb;
    
    private GameManager gameManager;
    
    public int pointValue;
    
    
    public ParticleSystem explosionParticle;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        targetRb = GetComponent<Rigidbody>();
        
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(),ForceMode.Impulse);
        
        transform.position = RandomSpawnPosition();
        
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(_minSpeed, _maxSpeed);
    }

    private float RandomTorque()
    {
        return Random.Range(-_maxTorque, _maxTorque);
    }

    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-_xRange, _xRange), _ySpawnPosition);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    
}
