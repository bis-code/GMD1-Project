using UnityEngine;

namespace DefaultNamespace
{
    public class HealthUtility
    {
        private static HealthUtility instance;
        
        public void Damage(float health)
        {
            PlayerHealth.health -= health;
        }

        public void Hurt(float damageHealth)
        {
            PlayerHealth.health -= damageHealth;
            // isHurt = true;
        }

        public void Die(Animator animator, Rigidbody2D rb)
        {
            animator.SetTrigger("Dead");
            rb.bodyType = RigidbodyType2D.Static;
        }

        public static HealthUtility getInstance()
        {
            if (instance == null)
            {
                instance = new HealthUtility();
                return instance;
            }

            return instance;
        }
    }
}