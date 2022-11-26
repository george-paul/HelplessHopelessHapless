using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTarget : MonoBehaviour
{
    public bool isActiveThisFrame = false;
    public Color activeColor;
    public Color inactiveColor;


    private void Update() {
        if(isActiveThisFrame) {
            gameObject.GetComponent<SpriteRenderer>().material.color = activeColor;
            isActiveThisFrame = false;
        }
        else {
            gameObject.GetComponent<SpriteRenderer>().material.color = inactiveColor;
        }
    }
}
