using System;
using Enemy;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerAttack : MonoBehaviour
    {
        private EnemyHealth enemy;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                // EnemyHealth.health -= 1;
            }
        }
    }
}