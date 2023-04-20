using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private float damage = 0.1f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<PlayerHealth>() != null)
        {
            PlayerHealth playerHealth = collider.GetComponent<PlayerHealth>();
            playerHealth.Damage(damage);
        }
    }
}
