using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchListener : MonoBehaviour
{
    public GameObject mark;
    public Component touchCount;

    float lastTime;
    // Start is called before the first frame update
    void Start()
    {
        lastTime = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        lastTime -= Time.deltaTime;
        if (Time.timeScale == 0) return;
        
        if (Input.touchCount > 0 )
        {
            lastTime = 0.3f;
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

        if (Input.GetMouseButton(0) && lastTime < 0.0f)
        {
            lastTime = 0.3f;

            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y >= 6.0f)
            {
                return;
            }
            GetComponent<TouchCounter>().touchCount++;
            Instantiate(mark, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f)), Quaternion.identity);
        }

    }
}
