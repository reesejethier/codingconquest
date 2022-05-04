using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private bool unlocked;//Default value is false
    public Image unlockImage;
    public GameObject[] stars;


    private void Update()
    {
        //UpdateLevelImage();// TODO Move this method later
    }


    private void UpdateLevelStatus()
    {
        //Unlock next level Maybe if statements watching the flag...
        //LevelManager

    }

    private void UpdateLevelImage()
    {
        if (!unlocked)//if unlock is false means This level is clocked!
        {
            Debug.Log("The lock is on");
            unlockImage.gameObject.SetActive(true);

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(false);
            }

        }

        else//if unlock is true means This level can play!
        {
            Debug.Log("the lock is off");
            unlockImage.gameObject.SetActive(false);
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(true);
            }
        }
    }


    public void PressSelection(string _LevelName)//When we press this level, we can start the level scene [Mario]
    {
        //if user hovers over certain lock and press enter, load the World level scene 
       //Base it on parent gameobject...
        if(unlocked)
        {
            SceneManager.LoadScene(_LevelName);
        }
    }

}
