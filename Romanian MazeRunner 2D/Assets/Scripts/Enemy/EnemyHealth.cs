using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        public static float health;

        private void Start()
        {
            health = 1;
        }
        
        private void Update()
        {
            if (health < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}