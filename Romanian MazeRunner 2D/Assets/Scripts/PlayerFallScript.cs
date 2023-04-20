using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallScript : MonoBehaviour
{
    private Vector3 respawnPoint;

    public GameObject fallDetect;
    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        fallDetect.transform.position = new Vector2(transform.position.x, fallDetect.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetect")
        {
            transform.position = respawnPoint;
        }
        else if(collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
    }
}
