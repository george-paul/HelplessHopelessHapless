using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] CustomUIButton _newGameButton;

    void Start()
    {
        _newGameButton.OnEvent.AddListener(StartNewGame);
    }

    private void StartNewGame()
    {
        CustomSceneManager.Instance.LoadNewGameScene();
    }
}
