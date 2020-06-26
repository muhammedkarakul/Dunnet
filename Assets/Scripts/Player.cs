using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject cpuCard;
    private Rigidbody2D rigidBody;
    private Animator animator;

    [SerializeField]
    private float velocity = 0.0f;

    public AudioSource walkingAudioSource;
    public AudioSource shovelPickUpAudioSource;
    public AudioSource diggingAudioSource;
    public AudioSource cpuCardTakenAudioSource;
    public AudioSource foodTakenAudioSource;
    public AudioSource bearRoarAudioSource;
    public AudioSource bearEatingAudioSource;
    public AudioSource keyTakenAudioSource;
    public AudioSource doorUnlockAudioSource;
    public AudioSource doorLockedAudioSource;
    public AudioSource paperAudioSource;

    private bool horizontalMovementDirection; // true: Right, false: Left

    void Start()
    {
        horizontalMovementDirection = true;
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (GameManager.isGoingOutFromBuilding)
        {
            transform.position = new Vector3(46.645f, 2.031f, -1f);
        }
    }

    void Update()
    {
        if (GameManager.isInputAvailable)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            movement(horizontalInput, verticalInput);
            changeHorizontalDirection(horizontalInput);
            playWalkingAudioSource();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Shovel":
                shovelPickUpAudioSource.Play();
                break;
            case "CPU":
                cpuCardTakenAudioSource.Play();
                break;
            case "Food":
                foodTakenAudioSource.Play();
                break;
            case "Key":
                keyTakenAudioSource.Play();
                break;
            default: break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Dialog":
                rigidBody.velocity = new Vector2(0, 0);
                break;
            case "Dig":
                if (GameManager.isShovelTaken)
                {
                    diggingAudioSource.Play();
                    GameManager.isDigged = true;
                    cpuCard.SetActive(true);
                }
                break;
            case "DeadEnd":
                GameManager.isGoingOutFromBuilding = true;
                SceneManager.LoadScene(1);
                break;
            case "Case":
                paperAudioSource.Play();
                GameManager.isPasswordTaken = true;
                break;
            case "Bear":
                if (!(GameManager.isFoodTaken))
                {
                    bearRoarAudioSource.Play();
                    GameOver.isGameOver = true;
                }
                else
                {
                    bearEatingAudioSource.Play();
                }
                break;
            case "Building":
                if (GameManager.isKeyTaken)
                {
                    doorUnlockAudioSource.Play();
                }
                else
                {
                    doorLockedAudioSource.Play();
                }
                break;
            case "Macintosh":
                if (GameManager.isMacintoshTyping)
                {
                    Cast.isGameEnded = true;
                }
                break;
            default:
                break;
        }
    }

    private void playWalkingAudioSource() {
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            walkingAudioSource.Play();
        }
        else if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical") && walkingAudioSource.isPlaying)
        {
            walkingAudioSource.Pause();
        }
    }

    private void movement(float horizontal, float vertical)
    {
        rigidBody.velocity = new Vector2(horizontal * velocity, vertical * velocity);
        animator.SetFloat("velocity", Mathf.Abs(horizontal + vertical));
    }

    private void changeHorizontalDirection(float horizontalVelocity)
    {
        if (horizontalVelocity > 0 && !horizontalMovementDirection || horizontalVelocity < 0 && horizontalMovementDirection)
        {
            horizontalMovementDirection = !horizontalMovementDirection;
            Vector3 direction = transform.localScale;
            direction.x *= -1;
            transform.localScale = direction;
        }
    }
}
