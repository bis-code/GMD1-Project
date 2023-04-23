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
    public bool isHurt = false;
    public bool isDead = false;
    private PlayerHealth _playerHealth;
    private Rigidbody2D rb;

    private void Start()
    {
        health = 1;
        _playerHealth = GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            HealthUtility.GetInstance().Die(_playerHealth, rb);
        }
    }
}
