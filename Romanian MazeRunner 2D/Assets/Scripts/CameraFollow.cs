using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }
        // if (player.transform.localScale.x > 0f)
        // {
        //     playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        // }
    }
}
