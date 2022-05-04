using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideCanvas : MonoBehaviour
{
    // Start is called before the first frame update

    public Canvas canvasObj;
    void toggleCanvas()
    {

        canvasObj.GetComponent<Canvas>().enabled = false;
    }
}
