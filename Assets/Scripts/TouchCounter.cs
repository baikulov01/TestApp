using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchCounter : MonoBehaviour
{
    public int touchCount;
    public Text touchText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        touchText.text = touchCount.ToString();
    }
}
