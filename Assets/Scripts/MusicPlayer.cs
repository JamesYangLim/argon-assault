using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer: MonoBehaviour
{
    [SerializeField] float SecondsToLoadNextScene = 3f;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

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
