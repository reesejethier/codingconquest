using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System; //For Actions

public class HelpMenu : MonoBehaviour
{
    public static HelpMenu instance;
    string s = "";

    public void onClick(Button button)
    {
        s = button.name;
        this.LoadScene(s);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
