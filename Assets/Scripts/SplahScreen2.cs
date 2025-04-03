using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen2 : MonoBehaviour
{
    public float splashScreenDuration = 2f; // Time to show the splash screen
    void Start()
    {
        // Load the video scene after the delay
        Invoke("LoadVideoScene", splashScreenDuration);
    }

    void LoadVideoScene()
    {
        SceneManager.LoadScene("IntroVideo");
    }
}