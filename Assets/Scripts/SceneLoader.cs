using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader: MonoBehaviour
{
    [SerializeField] float SecondsToLoadNextScene = 3f;
    
    void Start()
    {
        Invoke(nameof(LoadNextScene), SecondsToLoadNextScene);
    }

    void LoadNextScene()
    {
        //var nextSceneBuildIndex = SceneManager.sceneCountInBuildSettings + 1;
        SceneManager.LoadScene(1);
    }
}