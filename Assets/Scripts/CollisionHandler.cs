using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In seconds")] [SerializeField] float LevelLoadDelay = 1.0f;
    [Tooltip("FX prefab on player")] [SerializeField] GameObject DeathFX;

    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    void StartDeathSequence()
    {
        SendMessage("FreezeController");
        DeathFX.SetActive(true);
        Invoke(nameof(LoadNextScene), LevelLoadDelay);
    }

    void LoadNextScene()
    {
        //var nextSceneBuildIndex = SceneManager.sceneCountInBuildSettings + 1;
        SceneManager.LoadScene(1);
    }
}
