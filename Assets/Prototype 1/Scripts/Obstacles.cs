using UnityEngine;

namespace Prototype_1.Scripts
{
    public class Obstacles : MonoBehaviour
    {
        private float _speed;
        private const float ZLimitRange = -20;

        private void FixedUpdate()
        {
            MoveTowardsTheCamera();
            SyncTheSpeed();
            CheckTheRangeLimit();
        }

        private void MoveTowardsTheCamera()
        {
            transform.Translate(Vector3.back * (_speed * Time.deltaTime), Space.World);
        }

        private void SyncTheSpeed()
        {
            _speed = GameManager.instance.speed;
        }

        private void CheckTheRangeLimit()
        {
            if (transform.position.z < ZLimitRange)
            {
                Destroy(gameObject);
            }
        }
    }
}
