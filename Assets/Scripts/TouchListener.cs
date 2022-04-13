using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchListener : MonoBehaviour
{
    public GameObject mark;
    public Component touchCount;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (Camera.main.ScreenToWorldPoint(touch.position).y >= 6.0f)
            {
                return;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                GetComponent<TouchCounter>().touchCount++;
                Instantiate(mark, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f)), Quaternion.identity);
            }
        }

        if (Input.GetMouseButton(0))
        {

            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y >= 6.0f)
            {
                return;
            }
            GetComponent<TouchCounter>().touchCount++;
            Instantiate(mark, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f)), Quaternion.identity);
        }

    }
}
