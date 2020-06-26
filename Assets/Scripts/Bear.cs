using UnityEngine;
using UnityEngine.UI;

public class Bear : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator animator;

    [SerializeField]
    private float velocity = 0.0f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameObject.SetActive(!(GameManager.isBearLeaveTheScene));
    }

    private void Update()
    {
        gameObject.SetActive(!(GameManager.isBearLeaveTheScene));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameManager.isFoodTaken)
            {
                GameManager.isFoodThrowed = true;
                leaveScene();
            }
            else {
                gameOver();
            }
        } else if (collision.gameObject.tag == "SceneEdge")
        {
            GameManager.isBearLeaveTheScene = true;
        }
    }

    private void leaveScene()
    {
        rigidBody.velocity = new Vector2(velocity, 0);
        animator.SetFloat("velocity", Mathf.Abs(velocity));
        Vector3 direction = transform.localScale;
        direction.x *= -1;
        transform.localScale = direction;
    }

    private void gameOver() {
        Debug.Log("Game Over");
    }
}
