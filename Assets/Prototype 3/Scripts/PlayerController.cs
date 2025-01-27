using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static readonly int JumpTrig = Animator.StringToHash("Jump_trig");
    private static readonly int DeathB = Animator.StringToHash("Death_b");
    private Rigidbody _playerRb;
    public float jumpForce;
    public float gravityModMultiplier;
    public bool isOnGround;
    public bool gameOver = false;
    public Animator playerAnimation;
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModMultiplier;
        playerAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimation.SetTrigger(JumpTrig);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnimation.SetBool(DeathB, true);
        }
    }
}
