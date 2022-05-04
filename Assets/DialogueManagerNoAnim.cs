using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerNoAnim : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject DialogueDisplay;
    [SerializeField] GameObject Question;
    [SerializeField] GameObject Help;
    private Queue<string> sentences;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Time.timeScale = 0;
        DialogueDisplay.SetActive(true);
        //Debug.Log("Starting conversation with " + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        //Debug.Log(sentence);
        //dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        //Debug.Log("End of conversation.");
        DialogueDisplay.SetActive(false);
        Time.timeScale = 1;
    }

    public void HStartDialogue(Dialogue dialogue)
    {
        Time.timeScale = 0;
        Question.SetActive(false);
        Help.SetActive(false);
        DialogueDisplay.SetActive(true);
        //Debug.Log("Starting conversation with " + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        HDisplayNextSentence();
    }

    public void HDisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            HEndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        //Debug.Log(sentence);
        //dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void HEndDialogue()
    {
        //Debug.Log("End of conversation.");
        DialogueDisplay.SetActive(false);
        Question.SetActive(true);
        Help.SetActive(true);
    }
}
