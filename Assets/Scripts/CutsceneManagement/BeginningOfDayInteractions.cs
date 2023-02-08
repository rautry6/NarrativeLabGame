using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginningOfDayInteractions : MonoBehaviour
{
    [SerializeField] private GameObject[] dialogueScenes;
    [SerializeField] private GameObject dialogueBackground;

    private int currentScene = 0;
    private bool scenesFinished = false;

    // Start is called before the first frame update
    private void Awake()
    {
        dialogueScenes[currentScene].SetActive(true);
        dialogueBackground.SetActive(true);
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
                dialogueScenes[currentScene].SetActive(true);
            }
            else
            {
                //Disables dialogue background
                scenesFinished = true;
                dialogueBackground.SetActive(false);
            }
        }
    }


}
