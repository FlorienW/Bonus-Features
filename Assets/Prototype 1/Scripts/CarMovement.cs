using UnityEngine;

namespace Prototype_1.Scripts
{
    public class CarMovement : MonoBehaviour
    {
        public KeyCode leftKey;
        public KeyCode rightKey;
        public float leftBoundaryRange;
        public float rightBoundaryRange;
        public float speed;
        public float leftDirection ;
        public float rightDirection ;
        public float targetDirection;
        private float _currentVelocity;
        public float smoothTime;

        private void Start()
        {
            leftDirection = -25f;
            rightDirection = 25f;
        }

        private void Update()
        {
            GetInput();
            SyncTheRotation();
        }

        private void GetInput()
        {
            if (Input.GetKey(leftKey))
            {
                MoveToTheLeft();
            }

            else if (Input.GetKey(rightKey))
            {
                MoveToTheRight();
            }

            else
            {
                RotateToTheStraight();
            }
        }

        private void MoveToTheLeft()
        {
            transform.Translate(Vector3.left * (Time.deltaTime * speed), Space.World);
            RotateToTheLeft();
            if (transform.position.x < leftBoundaryRange)
            {
                transform.position = new Vector3(leftBoundaryRange, transform.position.y, transform.position.z);
                RotateToTheStraight();
            }
        }

        private void MoveToTheRight()
        {
            transform.Translate(Vector3.right * (Time.deltaTime * speed), Space.World);
            RotateToTheRight();
            if (transform.position.x > rightBoundaryRange)
            {
                transform.position = new Vector3(rightBoundaryRange, transform.position.y, transform.position.z);
                RotateToTheStraight();
            }
        }

        private void RotateToTheStraight()
        {
            targetDirection = 0;
        }

        private void RotateToTheLeft()
        {
            targetDirection = leftDirection;
        }

        private void RotateToTheRight()
        {
            targetDirection = rightDirection;
        }

        private void SyncTheRotation()
        {
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetDirection, ref _currentVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
}
