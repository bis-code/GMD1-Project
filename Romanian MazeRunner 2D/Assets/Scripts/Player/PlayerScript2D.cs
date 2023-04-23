using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class PlayerScript2D : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private TrailRenderer tr;
    [SerializeField]
    private GameObject fallDetect;
    [SerializeField]
    private GameObject attackArea;


    //attack
    private bool isAttacking = false;
    private float timeToAttack = 0.25f;
    private float timer = 0f;

    //dash
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;
    private Vector2 mousePosition;
    private Vector3 respawnPoint;

    private Animator _playerAnimator;
    private PlayerHealth _playerHealth;


    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }

        if(isAttacking)
        {
            timer += Time.deltaTime;
            
            if(timer >= timeToAttack)
            {
                ResetAttacking();
            }
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _playerAnimator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        _playerAnimator.SetBool("OnGround", IsGrounded());
        _playerAnimator.SetBool("IsAttacking", isAttacking);
    }

    public void FixedUpdate()
    {
        //player don't jump or do anything else if dashing
        if (isDashing)
        {
            return;
        }

        if(rb.bodyType != RigidbodyType2D.Static)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (isDashing) return;

        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (!canDash) return;
        StartCoroutine(Dash());
    }

    public void Attack(InputAction.CallbackContext context)
    {
        Attack();
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (isDashing) return;
        horizontal = context.ReadValue<Vector2>().x;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
        tr.emitting = false;
    }

    private void Attack()
    {
        isAttacking = true;
        attackArea.SetActive(isAttacking);
    }

    private void ResetAttacking()
    {
        timer = 0;
        isAttacking = false;
        attackArea.SetActive(isAttacking);
    }

    public void isPlayerDead(bool deadState)
    {
        
    }
}