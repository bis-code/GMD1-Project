using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static float health;
    private bool isHurt = false;
    private Animator playerAnimator;
    private Rigidbody2D rb;

    private void Start()
    {
        health = 1;
        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            HealthUtility.GetInstance().Die(playerAnimator, rb);
        }
    }
}
