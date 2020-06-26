using UnityEngine;

public class CPUCard : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(GameManager.isDigged && !(GameManager.isCPUCartTaken));
    }

    void Update()
    {
        gameObject.SetActive(GameManager.isDigged && !(GameManager.isCPUCartTaken));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.isCPUCartTaken = true;
            gameObject.SetActive(!(GameManager.isCPUCartTaken));
        }
    }
}
