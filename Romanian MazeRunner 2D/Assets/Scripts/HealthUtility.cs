using UnityEngine;

namespace DefaultNamespace
{
    public class HealthUtility: IHealthUtility
    {
        private bool isHurt = false;
        private Rigidbody2D rb;
        private Animator animator;

        public void Damage(float health)
        {
            PlayerHealth.health -= health;
            Debug.Log(PlayerHealth.health);
        }

        public void Hurt()
        {
            isHurt = true;
        }

        public void Die()
        {
            animator.SetTrigger("Dead");
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
}