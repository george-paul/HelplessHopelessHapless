using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShootButtonForDoor : MonoBehaviour
{
    public bool isOn = false;
    public Sprite onSprite;
    public Sprite offSprite;

    public GameObject[] associatedDoors;

    public void ToggleButton() {
        if (!isOn)
            TurnOnButton();
        else
            TurnOffButton();
    }

    private Light2D buttonLight;
    private SpriteRenderer sprite;

    private void OnEnable() {
        buttonLight = transform.Find("Button Light").GetComponent<Light2D>();
        sprite = GetComponent<SpriteRenderer>();
    }


    private void TurnOnButton() {
        buttonLight.color = new Color((float)(0x84/0xFF), 1, 0, 1);
        sprite.sprite = onSprite;
        foreach(GameObject door in associatedDoors)
        {
            DoorOpening doorOpening = door.GetComponent<DoorOpening>();
            doorOpening.ToggleDoor();    
        }
        isOn = true;
    }

    private void TurnOffButton() {
        buttonLight.color = new Color(1, 0, (float)(0x02/0xFF), 1);
        sprite.sprite = offSprite;
        foreach(GameObject door in associatedDoors)
        {
            DoorOpening doorOpening = door.GetComponent<DoorOpening>();
            doorOpening.ToggleDoor();    
        }
        isOn = false;
    }
}
