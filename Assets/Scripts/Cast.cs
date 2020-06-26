using UnityEngine;
using UnityEngine.SceneManagement;

public class Cast : MonoBehaviour
{
    public static bool isGameEnded = false;

    public GameObject castUI;

    void Update()
    {
        if (isGameEnded)
        {
            castUI.SetActive(true);
        }
        else
        {
            castUI.SetActive(false);
        }
    }

    public void loadMenu()
    {
        isGameEnded = false;
        SceneManager.LoadScene(0);
    }
}
