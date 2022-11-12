using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float zOffset = -10f;
    public GameObject toFollow;

    private void Update() {
        transform.position = new Vector3(toFollow.transform.position.x, toFollow.transform.position.y, zOffset);
    }
}
