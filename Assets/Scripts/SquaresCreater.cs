using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquaresCreater : MonoBehaviour
{
    public GameObject graySquare;
    public GameObject redSquare;
    public GameObject greenSquare;
    public GameObject blueSquare;

    public int numberOfObjects;
    int grayCount = 1;
    int redCount = 1;
    int blueCount = 1;
    int greenCount = 1;

    public float width;
    public float height;

    void Start()
    {
        width = Camera.main.pixelWidth;
        height = Camera.main.pixelHeight;

        numberOfObjects = 30;

        for (int i = 0; i < numberOfObjects; i++)
        {
            int num = Random.Range(0,100);
            if (num < 50)
            {
                grayCount++;
            } 
            else if (num >= 50 && num < 70)
            {
                redCount++;
            }
            else if (num >= 70 && num < 90)
            {
                blueCount++;
            } 
            else
            {
                greenCount++;
            }
        }

        GenerateEntity(graySquare,grayCount);
        GenerateEntity(redSquare, redCount);
        GenerateEntity(greenSquare, greenCount);
        GenerateEntity(blueSquare, blueCount);
    }

    void GenerateEntity(GameObject obj, int count)
    {
        for (int i = 0; i < count; i++)
        {
            float posX = Random.Range(10, width);
            float posY = Random.Range(10, height - 40);
            Instantiate(obj, Camera.main.ScreenToWorldPoint(new Vector3(posX, posY, 10)), Quaternion.identity);
        }
    }

}
