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


    private Queue<string> sentenceQueue;
    public GameObject dialogBox;
   

    public void Awake()
    {
        sentenceQueue = new Queue<string>();
    }
    public void StartDialog(Dialog dialog)
    {
        dialogBox.SetActive(true);
        titleDisplay.text = dialog.name;
        sentenceQueue.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentenceQueue.Enqueue(sentence);
        }
        StartCoroutine(DisplayNextSentence());

    }

    private IEnumerator DisplayNextSentence()
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
        StartCoroutine(DisplayNextSentence());

    }

    private void EndDialog()
    {
        dialogBox.SetActive(false);
        
    }

  
}
