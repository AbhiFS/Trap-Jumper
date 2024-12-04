using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionArrow : MonoBehaviour
{
    [SerializeField] private RectTransform[] options; // Array of selectable options
    private RectTransform rect;                      // Reference to the arrow's RectTransform
    private int currentPosition;                     // Current position of the selection

    [SerializeField] private AudioClip interactSound; // Add sound effect for interaction

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // Change position of the selection arrow
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangePosition(-1); // Move up
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangePosition(1); // Move down
        }

        // Interact with options
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.E))
            Interact();
    }

    private void ChangePosition(int _change)
    {
        // Update the current position
        currentPosition += _change;

        // Loop around if out of bounds
        if (currentPosition < 0)
            currentPosition = options.Length - 1;
        else if (currentPosition > options.Length - 1)
            currentPosition = 0;

        // Move the arrow to the selected option
        rect.position = new Vector3(rect.position.x, options[currentPosition].position.y, rect.position.z);
    }

    private void Interact()
    {
        // Play the interact sound if it's assigned
        if (interactSound != null)
        {
            SoundManager.instance.PlaySound(interactSound);
        }
        else
        {
            Debug.LogWarning("Interact sound is not assigned!");
        }

        // Access the button component on each option and call its function
        options[currentPosition].GetComponent<Button>().onClick.Invoke();
    }
}
