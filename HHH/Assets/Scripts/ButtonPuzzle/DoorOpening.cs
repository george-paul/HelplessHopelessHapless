using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public float movingTime = 1f;
    private bool isOpen = false;
    public float closedAngle;
    public float openAngle;

    private void OnEnable() {
        // de-negativify the angles
        Debug.Log(transform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x % 360, transform.rotation.eulerAngles.y % 360, transform.rotation.eulerAngles.z % 360);
        Debug.Log(transform.rotation.eulerAngles.z);

        closedAngle = transform.rotation.eulerAngles.z;
        openAngle = (closedAngle + 90);
    }

    public void ToggleDoor() {
        // rb.SetRotation(openAngle);
        // transform.Rotate(new Vector3(0,0,1), openAngle);
        // startAngle = 0f;
        // endAngle = 90f;
        StopAllCoroutines();
        // isClosing = false;
        isOpen = !isOpen;
        StartCoroutine(TogglingDoor());
    }

    IEnumerator TogglingDoor() {
        while (transform.rotation.eulerAngles.z <= openAngle && transform.rotation.eulerAngles.z >= closedAngle)
        {
            float step = (openAngle - closedAngle) * (Time.deltaTime/movingTime);
            transform.Rotate(new Vector3(0,0,1), (isOpen)?(step):(-step) );
            Debug.Log(transform.rotation.eulerAngles.z);
            yield return null;
        }
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, (isOpen)?openAngle:closedAngle);
        // Debug.Log("Finished toggling");
        yield break;
    }
}
