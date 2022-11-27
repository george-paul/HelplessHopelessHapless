using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartsTracker : MonoBehaviour
{
    public int newPartNotificationDelay = 3;
    public int maxParts = 2;
    public int partCount = 0;

    private GameManager gameManager;

    private Text textComp;

    private void OnEnable() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        textComp = transform.Find("Parts Text").GetComponent<Text>();
    }

    public void AddPart() {
        partCount++;
        if(partCount >= maxParts) gameManager.WinGame();
        StartCoroutine(AddPartCoroutine());
    }

    IEnumerator AddPartCoroutine() {
        textComp.text = "You found a part !";
        yield return new WaitForSeconds(newPartNotificationDelay);
        textComp.text = "Parts: " + partCount.ToString();
        yield break;
    }
}
