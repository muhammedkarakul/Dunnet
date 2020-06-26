using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text titleText;
    public Text subtitleText;

    public Animator dialogueBoxAnimator;

    private Queue<string> subtitles;
    
    void Start()
    {
        subtitles = new Queue<string>();    
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue) {

        GameManager.isInputAvailable = false;

        dialogueBoxAnimator.SetBool("isOpen", true);

        titleText.text = dialogue.title;

        subtitles.Clear();

        foreach (string subtitle in dialogue.subtitles) {
            subtitles.Enqueue(subtitle);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (subtitles.Count == 0) {
            EndDialogue();
            return;
        }

        string subtitle = subtitles.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSubtitle(subtitle));
    }

    IEnumerator TypeSubtitle(string subtitle) {
        subtitleText.text = "";
        foreach (char letter in subtitle.ToCharArray()) {
            if (letter == ' ')
            {
                subtitleText.text += '\t';
            }
            else
            {
                subtitleText.text += letter;
            }
            yield return null;
        }
    }

    void EndDialogue() {
        dialogueBoxAnimator.SetBool("isOpen", false);
        GameManager.isInputAvailable = true;
    }
}
