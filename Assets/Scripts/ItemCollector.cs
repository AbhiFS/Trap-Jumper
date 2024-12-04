using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int score = 0; // To keep track of the player's score
    public TMP_Text scoreText; // Ui Text element to display score
    
    
     
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score; // Initialize score
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            Destroy(other.gameObject); // destroy the item when collected
            score++; // Increment the score
            scoreText.text = "Score: " + score; // Update the score text
        }
    }
}
