using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNext : MonoBehaviour
{
    // Start is called before the first frame update
   public void sceneLoader()
    {
        SceneManager.LoadScene("GameSelect");
    }
}
