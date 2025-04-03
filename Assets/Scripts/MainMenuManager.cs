using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // New Game Button
    public void OnNewGameButtonClicked()
    {
        // Load the first level or game scene
        SceneManager.LoadScene("SampleScene"); // Replace with your game scene name
    }

    // Continue Button
    public void OnContinueButtonClicked()
    {
        // Load the saved game (you’ll need to implement saving/loading logic)
        Debug.Log("Continue button clicked");
    }

    // Settings Button
    public void OnSettingsButtonClicked()
    {
        // Open the settings menu (you’ll need to create a settings UI)
        Debug.Log("Settings button clicked");
    }

    // Quit Button
    public void OnQuitButtonClicked()
    {
        // Quit the game
        Application.Quit();
    }
}