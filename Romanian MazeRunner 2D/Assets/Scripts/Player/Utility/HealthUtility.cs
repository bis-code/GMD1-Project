using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class HealthUtility
    {
        private static HealthUtility instance;

        public void Hurt(PlayerHealth playerHealth, float damageHealth)
        {
            PlayerHealth.health -= damageHealth;
            playerHealth.isHurt = true;
        }

        public void Die(PlayerHealth playerHealth, Rigidbody2D rb)
        {
            playerHealth.isDead = true;
            rb.bodyType = RigidbodyType2D.Static;
        }

        public static HealthUtility GetInstance()
        {
            if (instance == null)
            {
                instance = new HealthUtility();
            }

            return instance;
        }
    }
}