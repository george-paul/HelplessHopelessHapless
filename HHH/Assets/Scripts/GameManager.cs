using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Text gameOverText;
    private Image gameOverImage;
    private Text winText;
    private Image winImage;

    private void OnEnable() {
        gameOverText = GameObject.Find("Game Over Text").GetComponent<Text>();
        gameOverImage = GameObject.Find("Game Over Screen").GetComponent<Image>();
        winText = GameObject.Find("Win Text").GetComponent<Text>();
        winImage = GameObject.Find("Win Screen").GetComponent<Image>();
    }

    public void GameOver() {
        gameOverImage.enabled = true;
        gameOverText.enabled = true;
    }

    public void WinGame() {
        winImage.enabled = true;
        winText.enabled = true;
    }
}
