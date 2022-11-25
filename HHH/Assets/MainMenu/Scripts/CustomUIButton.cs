using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class CustomUIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerClickHandler
{
    [System.Serializable]

    public class CustomUIEvent : UnityEvent {}
    public CustomUIEvent OnEvent;

    public bool buttonEnabled = true;

    public Image backgroundGraphic;

    public Color defaultColor = Color.clear;
    public Color hoverColor = Color.grey;
    public Color pressedColor = Color.red;

    public Vector3 defaultScale = Vector3.one;
    public Vector3 hoverScale = Vector3.one;
    public Vector3 pressedScale = Vector3.one;

    // private void Awake()
    // {
    //     if (!buttonEnabled)
    //     {
    //         bgGraphic.color = Color.gray;
    //     }
    // }


    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(Transition(hoverScale, hoverColor, 0.1f));
        //OnEvent.Invoke();
        //Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(Transition(defaultScale, defaultColor, 0.1f));
        //Debug.Log("OnPointerExit");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(Transition(pressedScale, pressedColor, 0.1f));
        //Debug.Log("OnPointerDown");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(Transition(hoverScale, hoverColor, 0.1f));
        // OnEvent.Invoke();
        //Debug.Log("OnPointerClick");
    }

    public IEnumerator Transition(Vector3 newSize, Color newColor, float transitionTime)
    {
        float timer = 0;
        Vector3 startSize = transform.localScale;
        Color startColor = backgroundGraphic.color;

        while (timer < transitionTime)
        {
            timer += Time.deltaTime;
            yield return null;

            transform.localScale = Vector3.Lerp(startSize, newSize, timer / transitionTime);
            backgroundGraphic.color = Color.Lerp(startColor, newColor, timer / transitionTime);
        }
    }
}

