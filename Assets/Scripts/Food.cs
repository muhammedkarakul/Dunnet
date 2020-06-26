using UnityEngine;

public class Food : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(!(GameManager.isFoodTaken));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.isFoodTaken = true;
            gameObject.SetActive(!(GameManager.isFoodTaken));
        }
    }
}
