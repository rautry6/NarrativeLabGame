using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCutsceneHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] dialogueScenes;
    [SerializeField] private GameObject dialogueBackground;

    private int currentScene = 0;
    private bool scenesFinished = false;
    private bool awaitingInput = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DayEnd()
    {
        dialogueBackground.SetActive(true);

        //Code to determine who talks with you

        float rand = Random.Range(0, dialogueScenes.Length);

        dialogueScenes[(int)rand].SetActive(true);

        awaitingInput = true;
    }
}
