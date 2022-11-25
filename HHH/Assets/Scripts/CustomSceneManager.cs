using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    public static CustomSceneManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public enum SceneList
    {
        MainMenuScene,
        GameScene
    }

    public void LoadCustomScene(SceneList scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNewGameScene()
    {
        SceneManager.LoadScene(SceneList.GameScene.ToString());
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(SceneList.MainMenuScene.ToString());
    }

    // For future development
    // public void LoadNextScene()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    // }
}
