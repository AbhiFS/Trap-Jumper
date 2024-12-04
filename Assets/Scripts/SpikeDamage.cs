using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    public float damageAmount = 1f; // Adjust the damage value as needed

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Collision detected with: {collision.gameObject.name}, tag: {collision.tag}, position: {collision.transform.position}");

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Spike hit detected: " + collision.name);
            Health playerHealth = collision.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }

}

