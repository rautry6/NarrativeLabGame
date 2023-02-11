using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BeginningOfDayInteractions : MonoBehaviour
{
    [SerializeField] private GameObject[] dialogueScenes;
    [SerializeField] private List<TMP_Text> dialogues;
    [SerializeField] private GameObject dialogueBackground;
    [SerializeField, Range(0.01f, 0.2f)] private float textSpeed = 0.05f;

    private int currentScene = 0;
    private bool scenesFinished = false;

    // Start is called before the first frame update
    private void Awake()
    {
        dialogues = new List<TMP_Text>();
        dialogueScenes[currentScene].SetActive(true);
        dialogueBackground.SetActive(true);

        for(int i = 0; i < dialogueScenes.Length; i++)
        {
            dialogues.Add(dialogueScenes[i].GetComponentInChildren<TMP_Text>());
        }

        StartCoroutine(PrintText());
    }

    // Update is called once per frame
    void Update()
    {
        //Returns early if player has gone through all the dialogue
        if (scenesFinished) return;

        if (Input.anyKeyDown)
        {
            //Disables current dialogue scene
            dialogueScenes[currentScene].SetActive(false);

            //Increments current scene
            currentScene++;

            //Enables next scene if there is one
            if (currentScene < dialogueScenes.Length)
            {
                StopCoroutine(PrintText());
                dialogueScenes[currentScene].SetActive(true);
                StartCoroutine(PrintText());
            }
            else
            {
                //Disables dialogue background
                scenesFinished = true;
                dialogueBackground.SetActive(false);
                StopCoroutine(PrintText());
            }
        }
    }

    public IEnumerator PrintText()
    {
        string text = dialogues[currentScene].text;
        dialogues[currentScene].text = "";

        for (int i = 0; i < text.Length; i++)
        {
            dialogues[currentScene].text += text[i];
            yield return new WaitForSeconds(textSpeed);
        }

    }
}
