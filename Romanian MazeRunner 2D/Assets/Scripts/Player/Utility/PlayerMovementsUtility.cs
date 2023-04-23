﻿using System.Collections;
using DefaultNamespace.Model;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public class PlayerMovementsUtility
    {
        private static PlayerMovementsUtility _instance;

        public bool IsAttacking { get; private set; }
        public bool CanDash { get; private set; }
        public bool IsDashing { get; private set; }
        public float Timer { get; private set; }
        public float Horizontal { get; private set; }
        
        private bool _isFacingRight = true;
        

        //performs actions

        public void Attack(GameObject attackArea)
        {
            IsAttacking = true;
            attackArea.SetActive(IsAttacking);
        }

        public void Jump(InputAction.CallbackContext context, Rigidbody2D rb, Transform groundCheck, LayerMask groundLayer, float jumpingPower)
        {
            if (IsDashing) return;

            if (context.performed && IsGrounded(groundCheck, groundLayer))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            if (context.canceled && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
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
        public bool CanJump(InputAction.CallbackContext context, Transform groundCheck, LayerMask groundLayer)
        {
            return context.performed && IsGrounded(groundCheck, groundLayer);
        }
        
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

        public void PerformIsAttacking(GameObject attackArea, float timeToAttack)
        {
            if(IsAttacking)
            {
                Timer += Time.deltaTime;
            
                if(Timer >= timeToAttack)
                {
                    ResetAttacking(attackArea);
                }
            }

        }
        
        //resetters animations
        public void ResetAttacking(GameObject attackArea)
        {
            Timer = 0;
            IsAttacking = false;
            attackArea.SetActive(IsAttacking);
        }

        public void PerformAnimations(Animator playerAnimator, Rigidbody2D rb, Transform groundCheck, LayerMask groundLayer)
        {
            playerAnimator.SetFloat(Animations.Speed.ToString(), Mathf.Abs(rb.velocity.x));
            playerAnimator.SetBool(Animations.OnGround.ToString(), 
                PlayerMovementsUtility.GetInstance().IsGrounded(groundCheck, groundLayer));
            playerAnimator.SetBool(Animations.IsAttacking.ToString(), IsAttacking);
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
    }
}