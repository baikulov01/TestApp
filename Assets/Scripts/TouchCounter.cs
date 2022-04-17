using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchCounter : MonoBehaviour
{
    public int touchCount;
    public Text touchText;

    void Update()
    {
        touchText.text = touchCount.ToString();
    }
}
