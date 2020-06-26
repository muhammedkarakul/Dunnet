using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Building : MonoBehaviour
{
    public GameObject buildingOpen;
    public GameObject buildingClose;

    private void Start()
    {
        buildingOpen.SetActive(GameManager.isDoorOpen);
        buildingClose.SetActive(!(GameManager.isDoorOpen));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameManager.isKeyTaken)
            {
                buildingOpen.SetActive(true);
                buildingClose.SetActive(false);
                GameManager.isDoorOpen = true;
            }

            if (GameManager.isDoorOpen)
            {
                GameManager.isGoingOutFromBuilding = false;
                SceneManager.LoadScene(2);
            }
        }
    }
}
