using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField]
        private float maxHealth = 1f;
        private float currentHealth;

        private void Start()
        {
            currentHealth = maxHealth;
        }

        public void Update()
        {
            
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}