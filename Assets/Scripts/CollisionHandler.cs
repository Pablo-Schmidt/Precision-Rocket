using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
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
                Debug.Log("This is the Finish pad!");
                break;
            default:
                Debug.Log("Sorry you blew up");
                ReloadLevel();
                break;
       }

        void ReloadLevel()
        {
            SceneManager.LoadScene(0);
        }
    }

}
