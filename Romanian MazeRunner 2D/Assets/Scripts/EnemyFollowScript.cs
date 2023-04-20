using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowScript : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        
    }
}
