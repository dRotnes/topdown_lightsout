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
    private bool _canPass;

    private Queue<string> sentenceQueue;
    public GameObject dialogBox;

    public void Awake()
    {
        sentenceQueue = new Queue<string>();
    }
    public void Update()
    {

        
    }
    public void StartDialog(Dialog dialog)
    {
        dialogBox.SetActive(true);
        titleDisplay.text = dialog.name;
        sentenceQueue.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentenceQueue.Enqueue(sentence);
            Debug.Log(sentence);
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
        
        foreach (char letter in sentence.ToCharArray())
        {

            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
        yield return new WaitForSeconds(timeBetweenPhrases);
        StartCoroutine(DisplayNextSentence());

    }

    private void EndDialog()
    {
        dialogBox.SetActive(false);
        _canPass = false;

    }
}
