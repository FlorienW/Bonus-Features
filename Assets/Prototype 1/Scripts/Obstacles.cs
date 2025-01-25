using UnityEngine;

namespace Prototype_1.Scripts
{
    public class Obstacles : MonoBehaviour
    {
        public float speed;
        private const float ZLimitRange = -20;

        private void FixedUpdate()
        {
            MoveTowardsTheCamera();
            SyncTheSpeed();
            CheckTheRangeLimit();
        }

        private void MoveTowardsTheCamera()
        {
            transform.Translate(Vector3.back * (speed * Time.deltaTime), Space.World);
        }

        public virtual void SyncTheSpeed()
        {
            speed = GameManager.instance.speed;
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
