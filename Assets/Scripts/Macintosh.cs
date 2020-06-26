using UnityEngine;
using UnityEngine.UI;

public class Macintosh : MonoBehaviour
{
    public GameObject macintoshTurnedOff;
    public GameObject macintoshCursor;
    public GameObject macintoshTyping;
    public Image cpuImage;

    public AudioSource macintoshBootAudioSource;
    public AudioSource macintoshPasswordInputAudioSource;

    void Start()
    {
        macintoshTurnedOff.SetActive(!(GameManager.isMacintoshTurnedOn));
        macintoshCursor.SetActive(GameManager.isMacintoshTurnedOn);
        macintoshTyping.SetActive(GameManager.isMacintoshTyping);
    }

    private void Update()
    {
        macintoshTurnedOff.SetActive(!(GameManager.isMacintoshTurnedOn));
        macintoshCursor.SetActive(GameManager.isMacintoshTurnedOn);
        macintoshTyping.SetActive(GameManager.isMacintoshTyping);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameManager.isCPUCartTaken && !(GameManager.isMacintoshTurnedOn))
            {
                macintoshBootAudioSource.Play();
                GameManager.isMacintoshTurnedOn = true;
                cpuImage.gameObject.SetActive(false);
            }

            if (GameManager.isPasswordTaken && GameManager.isMacintoshTurnedOn)
            {
                macintoshPasswordInputAudioSource.Play();
                GameManager.isMacintoshTyping = true;
            }
        }
    }
}
