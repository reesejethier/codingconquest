using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public float transition_time =1f;

   
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel("Problem"));
    }

    IEnumerator LoadLevel(string levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transition_time);
        SceneManager.LoadScene(levelIndex);
    }
}
