using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] float levelLoadDelay = 1f;
    void OnCollisionEnter(Collision other)
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

    void StartSuccessSequence()
    {
        GetComponent<Movement>().enabled = true;

    }

    void StartCrashSequence()
    {
        // to do add sfx upon crash
        //todo add particle effect upon crash
        audioSource.Play();
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