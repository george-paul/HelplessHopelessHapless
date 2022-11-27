using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RestartGame : MonoBehaviour
{
    private CustomSceneManager sceneManager;

    // input
    private PlayerInp inp;
    private void Awake() {
        inp = new PlayerInp();
    }
    private void OnEnable() {
        inp.Enable();
    }
    private void OnDisable() {
        inp.Disable();
    }

    private void Start() {
        sceneManager = GameObject.Find("CustomScenesManager").GetComponent<CustomSceneManager>();
        inp.Ground.RestartGame.performed += (ctx) => BackToMainMenu();
    }

    void BackToMainMenu() {
        sceneManager.LoadMainMenuScene();
    }
}
