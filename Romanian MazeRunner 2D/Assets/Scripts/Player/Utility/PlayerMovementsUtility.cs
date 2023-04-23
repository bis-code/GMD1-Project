using System.Collections;
using DefaultNamespace.Model;
using Enemy;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public class PlayerMovementsUtility
    {
        private static PlayerMovementsUtility _instance;

        public bool IsAttacking { get; private set; }
        public bool IsDashing { get; set; }
        public float Timer { get; private set; }
        public float Horizontal { get; private set; }
        
        private bool _isFacingRight = true;
        public bool CanDash = true;
        

        //performs actions

        public void Attack(Transform attackPoint, float attackRange, LayerMask enemyLayers, float playerDamage)
        {
            IsAttacking = true;
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            Debug.Log(hitEnemies);
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(playerDamage);
            }
        }

        public void Jump(InputAction.CallbackContext context, Rigidbody2D rb, Transform groundCheck, LayerMask groundLayer, float jumpingPower)
        {
            if (IsDashing) return;

            var velocity = rb.velocity;
            if (context.performed && IsGrounded(groundCheck, groundLayer))
            {
                rb.velocity = new Vector2(velocity.x, jumpingPower);
            }

            if (context.canceled && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(velocity.x, velocity.y * 0.5f);
            }
        }

        public IEnumerator Dash(Transform transform, Rigidbody2D rb, TrailRenderer tr, float dashingPower, float dashingTime, float dashingCooldown)
        {
            CanDash = false;
            IsDashing = true;
            rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
            tr.emitting = true;
            yield return new WaitForSeconds(dashingTime);
            IsDashing = false;
            yield return new WaitForSeconds(dashingCooldown);
            CanDash = true;
            tr.emitting = false;
        }

        public void Move(InputAction.CallbackContext context)
        {
            if (IsDashing) return;
            Horizontal = context.ReadValue<Vector2>().x;
        }
        
        //verifiers

        public bool IsGrounded(Transform groundCheck, LayerMask groundLayer)
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }
        
        //helpers for animations
        public void ChangeOrientationOfPlayer(Transform transform)
        {
            if (!_isFacingRight && Horizontal > 0f)
            {
                Flip(transform);
            }
            else if (_isFacingRight && Horizontal < 0f)
            {
                Flip(transform);
            }
        }
        
        private void Flip(Transform transform)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

        public void PerformIsAttacking(float timeToAttack)
        {
            if(IsAttacking)
            {
                Timer += Time.deltaTime;
            
                if(Timer >= timeToAttack)
                {
                    ResetAttacking();
                }
            }
        }

        //resetters animations
        public void ResetAttacking()
        {
            Timer = 0;
            IsAttacking = false;
        }

        public void PerformAnimations(Animator playerAnimator, Rigidbody2D rb, Transform groundCheck, LayerMask groundLayer, PlayerHealth playerHealth)
        {
            playerAnimator.SetFloat(Animations.Speed.ToString(), Mathf.Abs(rb.velocity.x));
            playerAnimator.SetBool(Animations.OnGround.ToString(), 
                PlayerMovementsUtility.GetInstance().IsGrounded(groundCheck, groundLayer));
            playerAnimator.SetBool(Animations.IsAttacking.ToString(), IsAttacking);
            playerAnimator.SetBool(Animations.IsDashing.ToString(), IsDashing);
            playerAnimator.SetBool(Animations.IsHurt.ToString(), playerHealth.isHurt);
            if (playerHealth.isDead)
            {
                playerAnimator.SetTrigger(Animations.Dead.ToString());
            }
        }
        
        //singleton
        public static PlayerMovementsUtility GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PlayerMovementsUtility();
            }
            return _instance;
        }

        public void playAudioClip(Animator animator)
        {
            
        }
    }
}