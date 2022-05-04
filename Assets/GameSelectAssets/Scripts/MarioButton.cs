using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarioButton : MonoBehaviour
{

    public void loadScene()
    {
        SceneManager.LoadScene("WorldMap");
    }


}
