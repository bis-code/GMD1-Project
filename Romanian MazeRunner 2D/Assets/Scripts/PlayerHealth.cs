using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isHurt = false;

    private void Start()
    {
        maxHealth = health;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health <= 0)
        {
            Die();
        }

        animator.SetBool("IsHurt", isHurt);
        isHurt = false;
    }

    public void Damage(int health)
    {
        this.health -= health;
        Debug.Log(this.health);
    }

    public void Hurt()
    {
        isHurt = true;
    }

    public void ResetHurtTrigger()
    {
        animator.ResetTrigger("Hurt");
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
