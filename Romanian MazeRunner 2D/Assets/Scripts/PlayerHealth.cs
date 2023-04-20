using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static float health;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isHurt = false;

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
            Die();
        }

        animator.SetBool("IsHurt", isHurt);
        isHurt = false;
    }

    public void Damage(float health)
    {
        PlayerHealth.health -= health;
        Debug.Log(PlayerHealth.health);
    }

    public void Hurt()
    {
        isHurt = true;
    }

    //todo make it on enemy with health
    public void Die()
    {
        animator.SetTrigger("Dead");
        rb.bodyType = RigidbodyType2D.Static;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
