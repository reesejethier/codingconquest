using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

/* Spawn object if bumped by Player's head
 * Applicable to: Collectible brick and question blocks
 */

public class CollectibleBlock : MonoBehaviour
{
    private Animator m_Animator;
    private LevelManager t_LevelManager;
    public bool isPowerupBlock;
    public bool isStar;
    public bool isOneUp;
    //comment
    public GameObject objectToSpawn;
    public GameObject starMan;
    public GameObject oneUp;
    public GameObject bigMushroom;
    public GameObject blockCoin;
    public GameObject fireFlower;
    public int timesToSpawn = 1;
    public Vector3 spawnPositionOffset;
    QuestionController q1;
    private float WaitBetweenBounce = .25f;
    private bool isActive;
    private float time1, time2;
    InputField input;
    public List<GameObject> enemiesOnTop = new List<GameObject>();

    //ACTION: part of events and delegates
    public static Action<CollectibleBlock> onHit;

    //List of attempt object locations
    //List<string> questList = new List<string> { "Q1/Question/Canvas/Back_Panel/Question_Panel/Attempt", "Q2/Question/Canvas/Back_Panel/Question_Panel/Attempt" };
    //not to test the thing
    int questionCounter = 0;

    // Use this for initialization
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        t_LevelManager = FindObjectOfType<LevelManager>();

        time1 = Time.time;
        isActive = true;

        
        q1 = GameObject.Find("QuestionController").GetComponent<QuestionController>();
        input = GameObject.Find("QuestionController").GetComponent<InputField>();
        

        //Debug.Log("QuestionObject:" + q1);
        //Debug.Log("InputFieldObject:" + input);

        StartCoroutine(delayScript());
    }
    //comment

    public void giveReward(bool isCorrect)
    {
        //Debug.Log("I am here");
        if (isCorrect == true)
        {
            //Debug.Log("Times to spawn:" + timesToSpawn);
            //Debug.Log("REWARD DECIDE isCorrect" + isCorrect);
            //Debug.Log("mario size: " + t_LevelManager.marioSize);


            if (isPowerupBlock)
            {
                if (t_LevelManager.marioSize == 0)
                {
                    objectToSpawn = bigMushroom;
                }

                else
                {
                    objectToSpawn = fireFlower;
                }

                questionCounter++;
                Instantiate(objectToSpawn, transform.position + spawnPositionOffset, Quaternion.identity);
                timesToSpawn--;
            }

            /*
            else if (!isStar && !isOneUp && !isPowerupBlock)
            {

                objectToSpawn = blockCoin;
                t_LevelManager.AddCoin();
                Instantiate(objectToSpawn, transform.position + spawnPositionOffset, Quaternion.identity);
                timesToSpawn--;
            }

            else
            {
                if (isStar)
                {
                    objectToSpawn = starMan;
                    Instantiate(objectToSpawn, transform.position + spawnPositionOffset, Quaternion.identity);
                    timesToSpawn--;
                }
                else if (isOneUp)
                {
                    objectToSpawn = oneUp;
                    Instantiate(objectToSpawn, transform.position + spawnPositionOffset, Quaternion.identity);
                    timesToSpawn--;
                }
            }


            */
            if (timesToSpawn == 0)
            {
                m_Animator.SetTrigger("deactivated");
                isActive = false;
            }
        }
        else
        {
            objectToSpawn = null;
            //Debug.Log("Wrong Answer! You're dumb.");
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        //float random = Random.Range(0, 2);

        //Give user a task, if completed, give reward
        //Debug.Log("The text is showing");
        //Generate random problem number and open that scene
        //change the scene to block's problem
        //save last load and player's position

        time2 = Time.time;
        if (other.tag == "Player" && time2 - time1 >= WaitBetweenBounce)
        {

            t_LevelManager.soundSource.PlayOneShot(t_LevelManager.bumpSound);

            if (isActive)
            {


                m_Animator.SetTrigger("bounce");

                // Hit any enemy on top
                foreach (GameObject enemyObj in enemiesOnTop)
                {
                    t_LevelManager.BlockHitEnemy(enemyObj.GetComponent<Enemy>());
                }

                if (timesToSpawn > 0)
                {
                    if (isPowerupBlock)
                    {
                        //on hit, check for listeners (if listeners, invoke functions)
                        onHit?.Invoke(this);

                        /*
                            if (t_LevelManager.marioSize == 0)
                            {
                                objectToSpawn = bigMushroom;
                            }
                            else
                            {
                                objectToSpawn = fireFlower;
                            }


                            questionCounter++;


                        Instantiate(objectToSpawn, transform.position + spawnPositionOffset, Quaternion.identity);
                        timesToSpawn--;
                        */
                    }

                    else if(!isStar && !isOneUp && !isPowerupBlock)
                    {
                        
                        objectToSpawn = blockCoin;
                        //t_LevelManager.AddCoin();
                        Instantiate(objectToSpawn, transform.position + spawnPositionOffset, Quaternion.identity);
                        timesToSpawn--;
                    }

                    else
                    {
                        if(isStar)
                        {
                            objectToSpawn = starMan;
                            Instantiate(objectToSpawn, transform.position + spawnPositionOffset, Quaternion.identity);
                            timesToSpawn--;
                        }
                        else if(isOneUp)
                        {
                            objectToSpawn = oneUp;
                            Instantiate(objectToSpawn, transform.position + spawnPositionOffset, Quaternion.identity);
                            timesToSpawn--;
                        }
                    }
                    

                    if (timesToSpawn == 0)
                    {
                        m_Animator.SetTrigger("deactivated");
                        isActive = false;
                    }
                        
                    }
                }

                time1 = Time.time;
            }
        }
    

        // check for enemy on top
        void OnCollisionStay2D(Collision2D other)
        {
            Vector2 normal = other.contacts[0].normal;
            Vector2 topSide = new Vector2(0f, -1f);
            bool topHit = normal == topSide;
            if (other.gameObject.tag.Contains("Enemy") && topHit && !enemiesOnTop.Contains(other.gameObject))
            {
                enemiesOnTop.Add(other.gameObject);
            }
        }
        void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.tag.Contains("Enemy"))
            {
                enemiesOnTop.Remove(other.gameObject);
            }
        }

        IEnumerator delayScript()
        {
            while (!q1.isFinished)
            {
                yield return new WaitForSeconds(10);
            }
        }
    
}





