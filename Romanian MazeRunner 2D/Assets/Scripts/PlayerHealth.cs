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

    private Rigidbody2D rb;
    private Animator animator;
    private bool isHurt = false;
    private IHealthUtility _healthUtility;

    private void Start()
    {
        health = 1;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            _healthUtility.Die();
        }

        animator.SetBool("IsHurt", isHurt);
        isHurt = false;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
