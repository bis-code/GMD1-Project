﻿using UnityEngine;

namespace DefaultNamespace
{
    public class HealthUtility
    {
        private static HealthUtility instance;

        public void Hurt(Animator animator, float damageHealth)
        {
            PlayerHealth.health -= damageHealth;
            animator.SetBool("IsHurt", true);
        }

        public void Die(Animator animator, Rigidbody2D rb)
        {
            animator.SetTrigger("Dead");
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