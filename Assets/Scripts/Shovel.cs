using UnityEngine;

public class Shovel : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(!(GameManager.isShovelTaken));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.isShovelTaken = true;
            gameObject.SetActive(!(GameManager.isShovelTaken));
        }
    }
}
