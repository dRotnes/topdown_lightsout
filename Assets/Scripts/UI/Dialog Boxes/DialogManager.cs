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


    private Queue<string> sentenceQueue;
    private bool _nonTyped;
   

    public void Awake()
    {
        sentenceQueue = new Queue<string>();
    }
    public void StartDialog(Dialog dialog, bool isTyped)
    {
        dialogBox.SetActive(true);
        titleDisplay.text = dialog.name;
        sentenceQueue.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentenceQueue.Enqueue(sentence);
        }
        if(isTyped == true)
        {
            StartCoroutine(DisplayTyped());
            _nonTyped = false;
        }
        else
        {
            DisplayNonTyped();
            _nonTyped = true;
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown("return") && _nonTyped)
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
        dialogBox.SetActive(false);
        
    }

  
}
