using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterButton : MonoBehaviour
{
    public Text CounterText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addOne()
    {
        CounterText.text = System.Convert.ToString(System.Convert.ToInt16(CounterText.text)+1);
    }
}
