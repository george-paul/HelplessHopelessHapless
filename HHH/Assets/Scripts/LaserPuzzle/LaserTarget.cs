using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTarget : MonoBehaviour
{
    public bool isActiveThisFrame = false;
    public Color activeColor;
    public Color inactiveColor;
    private SpriteRenderer sprite;

    private void OnEnable() {
        sprite = GetComponent<SpriteRenderer>();
    }

    public bool isActive () {
        if(sprite.material.color.Equals(activeColor)) {
            return true;
        }
        else return false;
    }

    private void Update() {
        if(isActiveThisFrame) {
            sprite.material.color = activeColor;
            isActiveThisFrame = false;
        }
        else {
            sprite.material.color = inactiveColor;
        }
    }
}
