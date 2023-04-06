using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript2D : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Weapon weapon;

    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private Vector2 mousePosition;
    private Vector3 respawnPoint;
    public GameObject fallDetect;

    private Animator playerAnimator;

   
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
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

        if (Input.GetMouseButtonDown(0)){
             weapon.Fire();
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerAnimator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        playerAnimator.SetBool("OnGround", IsGrounded());
    }

    public void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        Vector2 aimDirection = mousePosition - rb.position; 
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f; 
        rb.rotation = aimAngle;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
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

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}
