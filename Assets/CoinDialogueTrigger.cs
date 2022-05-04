using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDialogueTrigger : MonoBehaviour
{
    [SerializeField] LevelManager lm;
    [SerializeField] GameObject trigger;
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
            if (lm.coins == 1) {
                trigger.GetComponent<DialogueTriggerNoAnim>().TriggerDialogue();
                did = true;
            }
        }
    }
}
