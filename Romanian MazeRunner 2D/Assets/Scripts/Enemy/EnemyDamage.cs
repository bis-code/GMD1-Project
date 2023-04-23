using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Animator animator = other.gameObject.GetComponent<Animator>();
            HealthUtility.GetInstance().Hurt(animator, damage);
        }
    }
}
