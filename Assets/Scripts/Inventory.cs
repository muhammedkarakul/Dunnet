using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image shovelImage;
    public Image cpuImage;
    public Image foodImage;
    public Image keyImage;
    // Start is called before the first frame update
    void Start()
    {
        shovelImage.gameObject.SetActive(GameManager.isShovelTaken);
        cpuImage.gameObject.SetActive(GameManager.isCPUCartTaken && !(GameManager.isMacintoshTurnedOn));
        foodImage.gameObject.SetActive(GameManager.isFoodTaken && !(GameManager.isFoodThrowed));
        keyImage.gameObject.SetActive(GameManager.isKeyTaken && !(GameManager.isDoorOpen));
    }

    // Update is called once per frame
    void Update()
    {
        shovelImage.gameObject.SetActive(GameManager.isShovelTaken);
        cpuImage.gameObject.SetActive(GameManager.isCPUCartTaken && !(GameManager.isMacintoshTurnedOn));
        foodImage.gameObject.SetActive(GameManager.isFoodTaken && !(GameManager.isFoodThrowed));
        keyImage.gameObject.SetActive(GameManager.isKeyTaken && !(GameManager.isDoorOpen));
    }
}
