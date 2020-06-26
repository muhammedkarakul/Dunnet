using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(!(GameManager.isKeyTaken));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.isKeyTaken = true;
            gameObject.SetActive(!(GameManager.isKeyTaken));
        }
    }
}
