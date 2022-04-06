using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHero : MonoBehaviour
{
    public Vector3 currentTarget;
    public Vector3 startPosition;
    public bool hasTarget;
    public float movementSpeed;
    public bool isMoving;

    public Queue<Vector2> movementQueue;


    // Start is called before the first frame update
    void Start()
    {
        movementQueue = new Queue<Vector2>();
        startPosition = transform.position;
    }



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
                if (!hasTarget)
                {
                    hasTarget = true;
                    currentTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    currentTarget.z = transform.position.z;
                }
                else
                {
                    movementQueue.Enqueue(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y >= 6.0f)
            {
                return;
            }
            if (!hasTarget)
            {
                hasTarget = true;
                currentTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentTarget.z = transform.position.z;
            }
            else
            {
                movementQueue.Enqueue(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }

        }

        if (hasTarget)
        {
            isMoving = true;
        }
        else if(movementQueue.Count > 0)
        {
            currentTarget = movementQueue.Dequeue();
            hasTarget = true;
        }

        if (isMoving)
        {
            Move();
        }
    }


    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, movementSpeed * Time.deltaTime);
        if (transform.position == currentTarget)
        {
            hasTarget = false;
            isMoving = false;


            startPosition = transform.position;
        }
    }

}
