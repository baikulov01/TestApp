using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrianglesCreater : MonoBehaviour
{
    public GameObject triangle;
    public int trianglesNumber = 7;

    public float width;
    public float height;

    // Start is called before the first frame update
    void Start()
    {
        width = Camera.main.pixelWidth;
        height = Camera.main.pixelHeight;

        for (int i = 0; i < trianglesNumber; i++)
        {
            float posX = Random.Range(10, width);
            float posY = Random.Range(10, height - 40);
            
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(Camera.main.ScreenToWorldPoint(new Vector2(posX, posY)), 1.0f);
            
            if (hitColliders.Length == 0)
            {
                Instantiate(triangle, Camera.main.ScreenToWorldPoint(new Vector3(posX, posY, 10)), Quaternion.identity);
            }
            else i--;
        }

    }


}
