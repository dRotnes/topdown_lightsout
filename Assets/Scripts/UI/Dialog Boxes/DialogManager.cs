using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI titleDisplay;
    public TextMeshProUGUI textDisplay;
    public float typingSpeed;
    public float timeBetweenPhrases;
    public GameObject dialogBox;
    private Queue<string> sentenceQueue = new Queue<string>();
    private bool _currentState;
    private bool _isTyped;

    public void StartDialog(Dialog dialog, bool type)
    {
        _isTyped = type;
        if (_currentState == false)
        {
            dialogBox.SetActive(true);
            titleDisplay.text = dialog.name;
            sentenceQueue.Clear();

            foreach (string sentence in dialog.sentences)
            {
                sentenceQueue.Enqueue(sentence);
            }
            if (_isTyped == true)
            {
                StartCoroutine(DisplayTyped());

            }
        }
        _currentState = true;

    }
    private void Update()
    {
        if (Input.GetKeyDown("space") && !_isTyped && _currentState)
        {
            DisplayNonTyped();
        }
    }

    private void DisplayNonTyped()
    {
        if (sentenceQueue.Count == 0)
        {
            EndDialog();
            return;
        }
        string sentence = sentenceQueue.Dequeue();
        Debug.Log(sentence);
        textDisplay.text = sentence;


    }
    private IEnumerator DisplayTyped()
    {

        if (sentenceQueue.Count == 0)
        {
            EndDialog();
            yield return null;
        }

        textDisplay.text = "";
        string sentence = sentenceQueue.Dequeue();

        FindObjectOfType<AudioManager>().Play("typingSound");
        foreach (char letter in sentence.ToCharArray())
        {

            textDisplay.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);

        }
        FindObjectOfType<AudioManager>().Stop("typingSound");
        yield return new WaitForSecondsRealtime(timeBetweenPhrases);
        StartCoroutine(DisplayTyped());


    }

    public void EndDialog()
    {
        sentenceQueue.Clear();
        textDisplay.text = "";
        titleDisplay.text = "";
        _currentState = false;
        dialogBox.SetActive(false);
    }

    public bool CurrentState()
    {
        return _currentState;
    }

}
