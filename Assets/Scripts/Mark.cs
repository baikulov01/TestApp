using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mark : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (player.transform.position.x == transform.position.x && player.transform.position.y == player.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
