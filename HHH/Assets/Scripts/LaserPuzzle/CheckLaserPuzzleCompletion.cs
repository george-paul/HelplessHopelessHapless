using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLaserPuzzleCompletion : MonoBehaviour
{
    public float targetCheckDelay = 1;
    public List<GameObject> targetObjectList;

    private List<LaserTarget> targetList = new List<LaserTarget>() {};
    private PartsTracker tracker;

    private void Start() {
        tracker = GameObject.Find("/Canvas/Parts Display").GetComponent<PartsTracker>();

        foreach(var target in targetObjectList) {
            targetList.Add(target.GetComponent<LaserTarget>());
        }

        StartCoroutine(CheckCompletion());
    }

    IEnumerator CheckCompletion() {
        while(true) {
            continueOuter:
            yield return new WaitForSeconds(targetCheckDelay);
            foreach(var target in targetList)
            {
                if(!target.isActive())
                    goto continueOuter;
            }
            // all active
            tracker.AddPart();
            yield break;
        }
    }
}
