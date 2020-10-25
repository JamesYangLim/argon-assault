using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float SecondsToLoadNextScene = 3f;

    void Start()
    {
        
    }

    void Update()
    {
        if (SecondsToLoadNextScene < Time.time)
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        var nextSceneBuildIndex = SceneManager.sceneCountInBuildSettings + 1;
        SceneManager.LoadScene(nextSceneBuildIndex);
    }
}
