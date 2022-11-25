using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuController : MonoBehaviour
{
    [SerializeField] CustomUIButton _newGameButton;
    [SerializeField] CustomUIButton _quitGameButton;
    public Slider volumeSlider;
    public AudioMixer volumeMixer;

    void Start()
    {
        _newGameButton.OnEvent.AddListener(StartNewGame);
        _quitGameButton.OnEvent.AddListener(QuitGame);
    }

    private void StartNewGame()
    {
        CustomSceneManager.Instance.LoadNewGameScene();
    }

    private void QuitGame()
    {
        CustomSceneManager.Instance.QuitGame();
    }

    public void SetVolume()
    {
        volumeMixer.SetFloat("MasterVolume", Mathf.Log10(volumeSlider.value) * 20);
    }
}
