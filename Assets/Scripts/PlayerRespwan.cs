using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound;
    private Transform currentCheckpoint;
    private Health playerHealth;
    private UIManager uiManager;


    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void CheckRespawn()
    {
        Debug.Log("CheckRespawn called."); // Add this log
        if (currentCheckpoint == null)
        {
            Debug.LogWarning("CurrentCheckpoint is null. GameOver will be called.");
            uiManager.GameOver();
            return;
        }

        transform.position = currentCheckpoint.position;
        playerHealth.Respawn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Checkpoint"))
        {
            currentCheckpoint = collision.transform;

            // Play checkpoint sound
            if (SoundManager.instance != null && checkpointSound != null)
            {
                SoundManager.instance.PlaySound(checkpointSound);
            }

            // Disable the checkpoint collider
            Collider2D checkpointCollider = collision.GetComponent<Collider2D>();
            if (checkpointCollider != null)
            {
                checkpointCollider.enabled = false;
            }

            // Trigger checkpoint animation
            Animator checkpointAnimator = collision.GetComponent<Animator>();
            if (checkpointAnimator != null)
            {
                checkpointAnimator.SetTrigger("Appear");
            }
        }
    }
}


