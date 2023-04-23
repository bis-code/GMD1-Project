using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Enemy;
using Enemy.model;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class EnemyScript : MonoBehaviour
{
    public static event Action<EnemyScript> OnEnemyKilled;
    [SerializeField] float health, maxHealth = 3f;

    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        health = maxHealth;
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        EnemyDirection previousEnemyDirection = new EnemyDirection(moveDirection, rb.rotation);
        EnemyDirection newEnemyDirection =
            EnemyUtility.GetInstance().UpdateEnemyDirection(target, transform, previousEnemyDirection);
            
        rb.rotation = newEnemyDirection.rotation;
        moveDirection = newEnemyDirection.moveDirection;
    }

    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        Debug.Log($"Damage Amount: {damageAmount}");
        health -= damageAmount;
        Debug.Log($"Health is now: {health}");

        if (health <= 0)
        {
            Destroy(gameObject);
            OnEnemyKilled?.Invoke(this);
        }
    }
}