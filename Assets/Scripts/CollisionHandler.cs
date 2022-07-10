using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Start":
                Debug.Log("Start platform");
                break;
            case "Finish":
                LoadNextLevel();
                Debug.Log("Finish platform");
                break;
            default:
                CrashSequence();
                Debug.Log("Dieeee");
                break;
        }
    }

    private void CrashSequence(){
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", 1f);
    }

    private void ReloadLevel()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevelIndex);
    }

    private void LoadNextLevel(){        
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentLevelIndex + 1;
        if(nextLevelIndex == SceneManager.sceneCountInBuildSettings){
            nextLevelIndex = 0;
        }
        SceneManager.LoadScene(nextLevelIndex);
    }
}
