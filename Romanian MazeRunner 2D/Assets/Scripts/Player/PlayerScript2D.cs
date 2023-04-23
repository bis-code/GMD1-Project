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
    [SerializeField]
    private float timeToAttack = 0.25f;
    [SerializeField]
    private float speed = 8f;
    [SerializeField]
    private float jumpingPower = 16f;
    [SerializeField]
    private float dashingPower = 24f;
    [SerializeField]
    private float dashingTime = 0.2f;
    [SerializeField]
    private float dashingCooldown = 1f;

    [SerializeField] private AudioClip audioClip;

    private Animator _playerAnimator;
    private PlayerHealth _playerHealth;
    private AudioSource _audioSource;


    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerHealth = GetComponent<PlayerHealth>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        PlayerMovementsUtility.GetInstance().ChangeOrientationOfPlayer(transform);

        PlayerMovementsUtility.GetInstance().PerformIsAttacking(attackArea, timeToAttack);
        
        PlayerMovementsUtility.GetInstance().PerformAnimations(_playerAnimator, _audioSource, audioClip, rb, groundCheck, groundLayer, _playerHealth);
    }

    public void FixedUpdate()
    {
        //player don't jump or do anything else if dashing
        if (PlayerMovementsUtility.GetInstance().IsDashing)
        {
            return;
        }

        if(rb.bodyType != RigidbodyType2D.Static)
        {
            rb.velocity = new Vector2(PlayerMovementsUtility.GetInstance().Horizontal * speed, rb.velocity.y);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        PlayerMovementsUtility.GetInstance().Jump(context, rb, groundCheck, groundLayer, jumpingPower);
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (!PlayerMovementsUtility.GetInstance().CanDash) return;
        IEnumerator enumerator = PlayerMovementsUtility.GetInstance().Dash(transform, rb, tr, dashingPower,
            dashingTime, dashingCooldown);
        StartCoroutine(enumerator);
    }

    public void Attack(InputAction.CallbackContext context)
    {
        PlayerMovementsUtility.GetInstance().Attack(attackArea);
    }

    public void Move(InputAction.CallbackContext context)
    {
        PlayerMovementsUtility.GetInstance().Move(context);
    }
}