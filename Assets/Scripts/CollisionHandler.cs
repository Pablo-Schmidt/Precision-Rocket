using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    //AudioSource audioSource;
    bool isTransitioning = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning) { return; }
        {
            switch (other.gameObject.tag)
            {
                case "Friendly":

                    Debug.Log("This is friendly");
                    break;
                case "Fuel":
                    Debug.Log("This is fuel");
                    break;
                case "Finish":
                    StartSuccessSequence();
                    Debug.Log("This is the Finish pad!");
                    break;
                default:
                    StartCrashSequence();
                    Debug.Log("Sorry you blew up");
                    break;
            }
        }
      
    }
    void StartSuccessSequence()
    {
        isTransitioning = true;
        audioSource.PlayOneShot(success);
        successParticles.Play();
        GetComponent<Movement>().enabled = true;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.PlayOneShot(crash);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void LoadNextLevel()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}

