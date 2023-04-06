using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyScript>(out EnemyScript enemyComponent))
        {
            enemyComponent.TakeDamage(1);
        }
        
        Destroy(gameObject);
    }
}