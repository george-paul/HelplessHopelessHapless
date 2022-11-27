using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [SerializeField] float delay = 3f;

    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogueLines;
    public int index;

    public float typingSpeed;
    public bool playerIsClose;
    public bool fixUpdate = false;

    // Update is called once per frame
    void Update()
    {
        if(playerIsClose && !fixUpdate)
        {
            if(dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Type());
                fixUpdate = true;
            }
        }

        if(dialogueText.text == dialogueLines[index])
        {
            StartCoroutine(DelayDisappear(delay));
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Type()
    {
        foreach(char letter in dialogueLines[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator DelayDisappear(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        zeroText();
    }

    public void NextLine()
    {
        if(index < dialogueLines.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Type());
        }
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            // dialoguePanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
