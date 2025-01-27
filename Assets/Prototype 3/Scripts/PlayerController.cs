using System.Collections;
using UnityEngine;

namespace Prototype_3.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        private static readonly int JumpTrig = Animator.StringToHash("Jump_trig");
        private static readonly int DeathB = Animator.StringToHash("Death_b");
        private static readonly int SpeedF = Animator.StringToHash("Speed_f");

        private Rigidbody _playerRb;
        
        public float jumpForce;
        public float gravityModMultiplier;
        public float walkingSpeed = 30;
        public float runningSpeed = 50;
        public float speed;
        
        public bool isOnGround;
        public bool gameOver;
        public bool isAbleToDoubleJump = true;
        
        public Animator playerAnimation;
        
        public AudioClip[] jumpClips;
        public AudioClip[] landingClips;
        public AudioClip[] deathClips;


        public GameObject gameoverUI;
        public GameObject deathParticles;
        
        void Start()
        {
            _playerRb = GetComponent<Rigidbody>();
            Physics.gravity *= gravityModMultiplier;
            playerAnimation = GetComponent<Animator>();
            speed = walkingSpeed;
            StartCoroutine(SpeedUp());
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && (isOnGround || isAbleToDoubleJump))
            {
                _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                if (isOnGround)
                {
                    AudioSource.PlayClipAtPoint(jumpClips[Random.Range(0, jumpClips.Length)], transform.position);
                    isOnGround = false;
                    playerAnimation.SetTrigger(JumpTrig);
                }
                else
                {
                    isAbleToDoubleJump = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                speed = runningSpeed;
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                speed = walkingSpeed;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                if (!isOnGround)
                {
                    AudioSource.PlayClipAtPoint(landingClips[Random.Range(0, landingClips.Length)], transform.position);
                    isOnGround = true;
                }
                isAbleToDoubleJump = true;
            }
            else
            {
                if (!gameOver)
                {
                    gameoverUI.SetActive(true);
                    AudioSource.PlayClipAtPoint(deathClips[Random.Range(0, deathClips.Length)], transform.position);
                    Instantiate(deathParticles, collision.transform.position, deathParticles.transform.rotation);
                    playerAnimation.SetFloat(SpeedF, 0);
                }
                gameOver = true;
                playerAnimation.SetBool(DeathB, true);
            }
        }

        private IEnumerator SpeedUp()
        {
            yield return new WaitForSeconds(3f);
            walkingSpeed *= 1.01f;
            runningSpeed *= 1.01f;
        }
        
    }
}
