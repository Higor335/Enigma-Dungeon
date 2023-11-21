using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    public AudioClip portalSound;
    public VideoPlayer videoPlayer;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = portalSound;
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player entered the portal
            PlayPortalSound();
        }
    }

    private void PlayPortalSound()
    {
        audioSource.Play();

        // Delay the execution of the next steps by the duration of the portal sound
        Invoke("PlayVideoAndLoadScene", audioSource.clip.length);
    }

    private void PlayVideoAndLoadScene()
    {
        // Assuming your VideoPlayer component is attached to the same GameObject as this script
        if (videoPlayer != null)
        {
            // Set the video to play on the main texture of the player's camera
            videoPlayer.renderMode = VideoRenderMode.CameraNearPlane;
            videoPlayer.targetCamera = Camera.main;

            // Play the video
            videoPlayer.Play();

            // Delay the execution of the next steps by the duration of the video
            Invoke("LoadNextScene", (float)videoPlayer.clip.length);
        }
        else
        {
            Debug.LogError("VideoPlayer component not assigned to the PortalController script.");
        }
    }

    private void LoadNextScene()
    {
        // Stop the video playback
        videoPlayer.Stop();

        // Load the next scene
        SceneManager.LoadScene("Mapa2");
    }
}
