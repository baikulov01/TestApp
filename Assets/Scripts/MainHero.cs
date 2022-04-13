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

    public string firstCollectedObjectName;
    public string lastCollectedObjectName;

    public Queue<Vector2> movementQueue;
    public int squaresLeft;


    // Start is called before the first frame update
    void Start()
    {
        movementQueue = new Queue<Vector2>();
        startPosition = transform.position;
        squaresLeft = Camera.main.GetComponent<SquaresCreater>().objectsNumber+4;
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
                movementQueue.Enqueue(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y >= 6.0f)
            {
                return;
            }
            movementQueue.Enqueue(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        }

        if (!hasTarget)
        {
            if (movementQueue.Count > 0)
            {
                hasTarget = true;
                currentTarget = movementQueue.Dequeue();
                isMoving = true;
            } else
            {
                isMoving = false;
            }
        } else
        {
            isMoving = true;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string objectName = collision.gameObject.name;


        if (firstCollectedObjectName.Equals(string.Empty))
        {
            firstCollectedObjectName = objectName;
        }
        if (squaresLeft==1)
        {
            lastCollectedObjectName = objectName;
        }

        switch (objectName)
        {
            case "Triangle":
                isMoving = false;
                transform.position = startPosition;
                startPosition = transform.position;
                hasTarget = false;
                while (movementQueue.Count > 0)
                {
                    movementQueue.Dequeue();
                }
                GameObject[] marks = GameObject.FindGameObjectsWithTag("mark");
                foreach (var item in marks)
                {
                    Destroy(item);
                }
                break;
            case "RedSquare":
                if (gameObject.transform.localScale.x > 0.4f)
                {
                    gameObject.transform.localScale -= new Vector3(0.15f, 0.15f, 0);
                }
                break;
            case "BlueSquare":
                gameObject.transform.localScale += new Vector3(0.15f, 0.15f, 0);
                break;
            case "GreenSquare":
                if (firstCollectedObjectName.Equals("GreenSquare"))
                {
                    Camera.main.GetComponent<TouchCounter>().touchCount--;
                } 
                else if (lastCollectedObjectName.Equals("GreenSquare"))
                {
                    Camera.main.GetComponent<TouchCounter>().touchCount++;
                }
                break;
        }

        if (!objectName.Equals("Triangle"))
        {
            Destroy(collision.gameObject);
            squaresLeft--;
        }      
    }

}
