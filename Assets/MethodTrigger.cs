using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodTrigger : MonoBehaviour
{
    [SerializeField] LevelManager lm;
   // [SerializeField] GameObject trigger;
    private bool did = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!did)
        {
            //Debug.Log("ay");
            if (lm.timeText.text == "380")
            {
                //  trigger.GetComponent("Ground").<DialogueTriggerNoAnim>().TriggerDialogue();

                GameObject.Find("MD1").GetComponent<DialogueTriggerNoAnim>().TriggerDialogue();
                
                did = true;
               
               
            }

        }

        if (did)
        {
            //Debug.Log("ay");
            if (lm.timeText.text == "360")
            {
                //  trigger.GetComponent("Ground").<DialogueTriggerNoAnim>().TriggerDialogue();

                GameObject.Find("MD2").GetComponent<DialogueTriggerNoAnim>().TriggerDialogue();

                did = false;
               

            }

        }

        if (!did)
        {
            //Debug.Log("ay");
            if (lm.timeText.text == "340")
            {
                //  trigger.GetComponent("Ground").<DialogueTriggerNoAnim>().TriggerDialogue();

                GameObject.Find("MD3").GetComponent<DialogueTriggerNoAnim>().TriggerDialogue();

                did = true;


            }

        }

        if (did)
        {
            //Debug.Log("ay");
            if (lm.timeText.text == "320")
            {
                //  trigger.GetComponent("Ground").<DialogueTriggerNoAnim>().TriggerDialogue();

                GameObject.Find("MD4").GetComponent<DialogueTriggerNoAnim>().TriggerDialogue();

                did = false;


            }

        }
    }
}
