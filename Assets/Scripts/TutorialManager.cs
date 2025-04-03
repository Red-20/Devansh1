using UnityEngine;
using TMPro;
using System.Collections; // Add this namespace for IEnumerator

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI instructionText; // Reference to the instruction text
    public GameObject arrow; // Reference to the arrow GameObject
    private int currentStep = 0; // Track the current step in the tutorial

    void Start()
    {
        // Start the tutorial
        UpdateInstruction();
    }

    void Update()
    {
        // Check for player input based on the current step
        switch (currentStep)
        {
            case 0: // Step 1: Press W to move forward
                if (Input.GetKeyDown(KeyCode.W))
                {
                    currentStep++;
                    UpdateInstruction();
                }
                break;

            case 1: // Step 2: Press S to move backward
                if (Input.GetKeyDown(KeyCode.S))
                {
                    currentStep++;
                    UpdateInstruction();
                }
                break;

            case 2: // Step 3: Press A to move left
                if (Input.GetKeyDown(KeyCode.A))
                {
                    currentStep++;
                    UpdateInstruction();
                }
                break;

            case 3: // Step 4: Press D to move right
                if (Input.GetKeyDown(KeyCode.D))
                {
                    currentStep++;
                    UpdateInstruction();
                }
                break;

            case 4: // Step 5: Press Ctrl to crouch
                if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
                {
                    currentStep++;
                    UpdateInstruction();
                }
                break;

            case 5: // Step 6: Press Space to jump
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    currentStep++;
                    UpdateInstruction();
                }
                break;

            default: // End of tutorial
                break;
        }
    }

    void UpdateInstruction()
    {
        // Update the instruction text based on the current step
        switch (currentStep)
        {
            case 0:
                instructionText.text = "Press W to move forward";
                break;
            case 1:
                instructionText.text = "Press S to move backward";
                break;
            case 2:
                instructionText.text = "Press A to move left";
                break;
            case 3:
                instructionText.text = "Press D to move right";
                break;
            case 4:
                instructionText.text = "Press Ctrl to crouch";
                break;
            case 5:
                instructionText.text = "Press Space to jump";
                break;
            default:
                // Show the final prompt and activate the arrow
                StartCoroutine(ShowFinalPrompt());
                break;
        }
    }

    IEnumerator ShowFinalPrompt()
    {
        // Show the final prompt
        instructionText.text = "The arrow will guide you";

        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        // Destroy the instruction text
        Destroy(instructionText.gameObject);

        // Activate the arrow
        arrow.SetActive(true);
    }
}