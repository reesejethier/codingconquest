using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyToLoad : MonoBehaviour
{
    // Start is called before the first frame update

    private void Start()
    {
        Object.Destroy(GameObject.Find("Game State Manager"));
        Object.Destroy(GameObject.Find("QuestionController"));
        Object.Destroy(GameObject.Find("QuestionList"));
    }
}
