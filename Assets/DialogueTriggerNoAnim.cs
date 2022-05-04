using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNoAnim : MonoBehaviour
{
    public Dialogue dialogue;
    GameObject dm;
    [SerializeField] bool h;

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
        if (h)
        {
            dm = GameObject.Find("HDialogueManager");
            dm.GetComponent<DialogueManagerNoAnim>().HStartDialogue(dialogue);
            //   Debug.Log("I am being called !!");
        }
        else
        {
            dm = GameObject.Find("DialogueManager");
            dm.GetComponent<DialogueManagerNoAnim>().StartDialogue(dialogue);
              //Debug.Log("I am being called !!");
        }

    }

}
