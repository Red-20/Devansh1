using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string mainMenuSceneName = "MainMenu"; // Name of the main menu scene

    void Start()
    {
        // Play the video
        videoPlayer.Play();

        // Load the main menu scene when the video ends
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}