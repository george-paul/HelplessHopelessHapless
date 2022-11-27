using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartsTracker : MonoBehaviour
{
    public int newPartNotificationDelay = 3;
    public int maxParts = 2;
    public int partCount = 0;

    private Text textComp;

    private void OnEnable() {
        textComp = transform.Find("Parts Text").GetComponent<Text>();
    }

    public void AddPart() {
        StartCoroutine(AddPartCoroutine());
    }

    IEnumerator AddPartCoroutine() {
        partCount++;
        textComp.text = "You found a part !";
        yield return new WaitForSeconds(newPartNotificationDelay);
        textComp.text = "Parts: " + partCount.ToString();
        yield break;
    }
}
