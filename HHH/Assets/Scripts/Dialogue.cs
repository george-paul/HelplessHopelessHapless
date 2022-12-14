using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    enum DialogueMap
    {
        MazeEntry,
        HaplessEntry,
        BossBattle,
        LaserPuzzle,
    };

    private string[][] dialogues = new string[][] {};


    [SerializeField] float delay = 3f;

    public Image dialoguePanel;
    public Text dialogueText;
    public string[] dialogueLines;
    public int index;

    public float typingSpeed;
    public bool playerIsClose;
    public bool fixUpdate = false;

    private void OnEnable() {

        dialogues = new string[][] {
            new string[] {
                "Hey! This looks like a maze!! Let's go in and see if we can find something useful"
            },
            new string[] {
                "Is that... Hapless? No... How... This wasn't supposed to happen. We were supposed to find you... Alive."
            },
            new string[] {
                "What in great tarnation is that thing?! [BOSS MUSIC STARTS]"
            },
            new string[] {
                "That's a lot of lasers. I wonder whether the lasers can power the lamps and let me through"
            },
        };

        dialoguePanel = GameObject.Find("/Canvas/DialoguePanel").GetComponent<Image>();
        dialogueText = GameObject.Find("/Canvas/DialoguePanel/DialogueText").GetComponent<Text>();
    }

    void SetVisibility(bool isVisible) {
        dialogueText.enabled = isVisible;
        dialoguePanel.enabled = isVisible;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerIsClose && !fixUpdate)
        {
            if(dialoguePanel.enabled)
            {
                zeroText();
            }
            else
            {
                // dialoguePanel.SetActive(true);
                SetVisibility(true);
                StartCoroutine(Type());
                fixUpdate = true;
            }
        }

        if(dialogueText.text == dialogueLines[index])
        {
            StartCoroutine(DelayDisappear(delay));
            fixUpdate = false;
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        // dialoguePanel.SetActive(false);
        SetVisibility(false);
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

    // public void NextLine()
    // {
    //     if(index < dialogueLines.Length - 1)
    //     {
    //         index++;
    //         dialogueText.text = "";
    //         StartCoroutine(Type());
    //     }
    //     else
    //     {
    //         zeroText();
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.CompareTo("Maze Trigger") == 0)
        {
            dialogueLines = dialogues[((int)DialogueMap.MazeEntry)];
            playerIsClose = true;
        }
        else if (other.name.CompareTo("Laser Puzzle Trigger") == 0)
        {
            dialogueLines = dialogues[((int)DialogueMap.LaserPuzzle)];
            playerIsClose = true;
        }
        else if (other.name.CompareTo("Paavam Hapless") == 0)
        {
            dialogueLines = dialogues[((int)DialogueMap.HaplessEntry)];
            playerIsClose = true;
        }
        else if (other.name.CompareTo("Boss Battle") == 0)
        {
            dialogueLines = dialogues[((int)DialogueMap.BossBattle)];
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name.CompareTo("Maze Trigger") == 0 || other.name.CompareTo("Laser Puzzle Trigger") == 0 || other.name.CompareTo("Paavam Hapless") == 0 || other.name.CompareTo("Boss Battle") == 0)
        {
            playerIsClose = false;
            fixUpdate = false;
            zeroText();
        }
    }
}
