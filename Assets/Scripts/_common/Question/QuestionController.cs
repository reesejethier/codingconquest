using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System; //For Actions

public class QuestionController : MonoBehaviour
{
    //Word related questions,change title,canvas, message,solution

    public bool isCorrect = false;
    public bool isFinished = false;
    public bool correct = false;
    public bool hasMoreQuestions = true;
    //public int numWrong = 0;
    public int iterator = 0;

    LevelManager lm;

    [SerializeField] public GameObject canvas;
    [SerializeField] Text titleText;
    [SerializeField] Text messageText;
    [SerializeField] InputField attempt;
    [SerializeField] Button button;
    [SerializeField] Text buttonText;
    [SerializeField] string solution;
    [SerializeField] Image questionImage;
    [SerializeField] bool hasImage;
    GameObject helpButton;
    public GameObject help;

    public QuestionList qList;
    private Question currentQuestion;
    QuestionController qc;

    //generic class that creates delegates
    //link events and delegates: https://www.youtube.com/watch?v=jQgwEsJISy0&t=1605s
    //observer patterns link: https://www.youtube.com/watch?v=Yy7Dt2usGy0

    public static Action<bool> onCorrect;
    private CollectibleBlock currentBlock;

    //CollectibleBlock cb;
    //float random;

    private string temp;



    private void Start()
    {
        Hide();
        UnityEngine.Object.DontDestroyOnLoad(GameObject.Find("QuestionController"));
        UnityEngine.Object.DontDestroyOnLoad(GameObject.Find("QuestionList"));

        CollectibleBlock.onHit += onBlockHit;
        if (qList.list.Length > 0)
            currentQuestion = qList.list[0];
        else hasMoreQuestions = false;
    }


    public void onBlockHit(CollectibleBlock block)
    {
        currentBlock = block;
        //Debug.Log("block: " + block);
        if (hasMoreQuestions)
        {
            Time.timeScale = 0;
            Show();
        }
        else currentBlock.giveReward(true);
    }

    /*
    private void Update()
    {
        
    }
    */

    public void Show()
    {
        titleText.text = "Pop quiz!";
        buttonText.text = "Skip";
        if (canvas.gameObject != null)
            canvas.gameObject.SetActive(true);
        isFinished = true;
        // StartCoroutine(lm.PauseGameCo());
        messageText.text = currentQuestion.text;
        solution = currentQuestion.answer;
        if (hasImage)
            questionImage.gameObject.SetActive(true);
        if (currentQuestion.image != null)
            questionImage.sprite = currentQuestion.image;
        else questionImage.gameObject.SetActive(false);
    }

    public void Hide()
    {
        //titleText.text = "Pop quiz!";
        //buttonText.text = "Skip";
        canvas.gameObject.SetActive(false);
        // StartCoroutine(lm.UnpauseGameCo());
        Time.timeScale = 1;

    }

    
    void Awake()
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(Hide);

    }

    /*
    public bool GetInput(string guess)
    {
        bool wait;
        Show();
        titleText.text = "Pop Quiz!";

        guess = attempt.text;
        Debug.Log("Getting input: " + guess);
        if(guess == "")
        {
            wait = true;
            StartCoroutine(WaitInput(wait));
            //WaitInput(wait);
        }
        else
        {
            wait = false;
            isBool = CompareAnswer(guess, solution);
            attempt.text = "";
        }
        

        return isBool;
    }
    */

    public void GetInput(string guess)
    {
        //NOTACCEPT
        guess = attempt.text;
        //Debug.Log("Getting input: " + guess);

        if (!string.IsNullOrWhiteSpace(guess))
        { 
           isCorrect = CompareAnswer(guess, solution);
            //Debug.Log("GET INPUT isCorrect: " + isCorrect);
            if(isCorrect)
            {
                //Debug.Log("hey i am here");
                currentBlock.giveReward(isCorrect);
                iterator++;
                titleText.text = "Correct!";
                buttonText.text = "Get Item";
                if (qList.list.Length <= iterator)
                {
                    hasMoreQuestions = false;
                }
                else currentQuestion = qList.list[iterator];
            }
        }
    }

   /* public void GetInputSilent(string guess)
    {
        GetInput(guess);
    }
   */
 
    //coroutine waitinput
    /*
    public static IEnumerator WaitInput(bool wait)
    {
        Debug.Log("Hey im in the coroutine lol");

        Debug.Log("wait is: " + wait);
        if (wait)
        {
            yield return new WaitForSeconds(30);
        }
        else
        {
            yield break;
        }
        yield break;
    }*/

    public bool CompareAnswer(string attempt, string answer)
    {
        temp = attempt.ToLower();

        if (temp.Contains(answer) == true)
        {
            titleText.text = "Correct!";
            correct = true;
            
        }
        else if (attempt != "" || !temp.Contains(answer))
        {
            titleText.text = "Try Again!";
            correct = false;
            //numWrong++;
        }

        //Debug.Log("I am inside Compare answer, at the end tho");

        return correct;
    }

    /*   public void showHelp()
       {
           if( numWrong > 0)
           {
               helpButton.SetActive(true);
           }

           else 
           { 
               helpButton.SetActive(false);
           }
    }*/

    public void helpClicked()
    {
        help.SetActive(true);
    }

}
