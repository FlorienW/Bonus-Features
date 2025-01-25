using UnityEngine;

namespace Prototype_1.Scripts
{
    public class Road : MonoBehaviour
    {
        private float _roadLength;
        private float _changeLocation;
        private float _speed;

        private void Start()
        {
            _roadLength = GetComponent<MeshRenderer>().bounds.size.z;
            _changeLocation = transform.position.z - _roadLength;
        }

        private void FixedUpdate()
        {
            MoveTowardsTheCamera();
            InfiniteRoad();
            SyncTheSpeed();
        }

        private void MoveTowardsTheCamera()
        {
            transform.Translate(Vector3.back * (_speed * Time.deltaTime), Space.World);
        }

        private void InfiniteRoad()
        {
            if (transform.position.z <= _changeLocation)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + _roadLength);
            }
        }

        private void SyncTheSpeed()
        {
            _speed = GameManager.instance.speed;
        }
    }
}
