using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    DialogueManager dm;

    [SerializeField] bool dialogueOnStart;

    private void Update()
    {
        if (dialogueOnStart)
        {
           
            dialogueOnStart = false;
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
     //   Debug.Log("I am being called !!");
    
    }

}
