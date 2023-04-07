using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;

    private bool isDead = false;
    public PlayerScript2D player;

    private void Start()
    {
        maxHealth = health;
    }

    private void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health <= 0)
        {
            isDead = true;
            Destroy(gameObject);
        }
        player.isPlayerDead(isDead);
    }

    public void Damage(int health)
    {
        this.health -= health;
        Debug.Log(this.health);
    }
}
