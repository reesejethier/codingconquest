using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionTrigger : MonoBehaviour
{
    [SerializeField] LevelManager lm;
    Mario mario;
    int size;
    private bool did = false;

    // Start is called before the first frame update
    void Start()
    {
        //get current size of mario
        size = lm.marioSize;
    }

    // Update is called once per frame
    void Update()
    {
        //if mario shrinks or powers up, trigger dialogue

        if (!did)
        {
            //Debug.Log("ay");
            if (lm.marioSize>size||lm.marioSize<size)
            {
                //  trigger.GetComponent("Ground").<DialogueTriggerNoAnim>().TriggerDialogue();

                GameObject.Find("CD1").GetComponent<DialogueTriggerNoAnim>().TriggerDialogue();

                did = true;


            }

        }

    }
}
