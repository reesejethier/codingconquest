using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class L1_Controller : MonoBehaviour
{
    
    private bool correct = false;

    [SerializeField]
    private InputField input;

    [SerializeField]
    private Text text;
    private string temp;
    private string ans1 = "public static void main()";
    private string ans2 = "yes";
    private string ans3 = "20";
    private string ans4 = "5";
    private string ans5 = "2";
    private string ans6 = "No";
    string lastScene;
    
    string sceneName;
    //PLAN
    /*
     * store answers for comparison
     Get current scene
    compare the scene and open it
    compare input to solution
    */


    public void GetInput(string guess)
    {
        Scene currentScence = SceneManager.GetActiveScene();
        sceneName = currentScence.name;
        if(sceneName == "Problem")
        {
            CompareAnswer(guess,ans1);
            input.text = "";
        }

        if (sceneName == "Problem2")
        {
            CompareAnswer(guess, ans2);
            input.text = "";
        }

        if (sceneName == "Problem3")
        {
            CompareAnswer(guess, ans3);
            input.text = "";
        }

        if (sceneName == "Problem4")
        {

            CompareAnswer(guess, ans4);
            input.text = "";
        }

        if (sceneName == "Problem5")
        {
            CompareAnswer(guess, ans5);
            input.text = "";
        }

        if (sceneName == "Problem6")
        {
            CompareAnswer(guess, ans6);
            input.text = "";
        }


        //go back to previous scene after question completion
        Debug.Log("Loading Previous Scene");
         lastScene = PlayerPrefs.GetString("LastLoadedScene");
         SceneManager.LoadScene(lastScene);
   



    }



    public bool CompareAnswer(string attempt,string answer)
    {
        temp = attempt.ToLower();
        
        if (temp.Contains(answer)==true)
        {
            text.text = "Correct!";
            correct = true;
        }
        else
        {
            text.text = "Not Correct";
            correct = false;
        }

        return correct;
    }

}
