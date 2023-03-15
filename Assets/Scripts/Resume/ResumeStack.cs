using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeStack : MonoBehaviour
{
    [Range(1, 100)]
    [SerializeField] private int numberOfResumes = 1;
    [SerializeField] private GameObject resumePrefab;
    [SerializeField] private GameObject spawnPoint;
    [Space]
    [SerializeField] private List<GameObject> resumes;
    [SerializeField] int listPos;
    [Range(1, 10)]
    [SerializeField] float slideSpeed = 1;

    Vector2 oGPos, slideStart;
    //[SerializeField] 
    float moveTime;
    //[SerializeField] 
    bool moveResume;


    void Start()
    {
        slideStart = oGPos = spawnPoint.transform.position;
        slideStart -= new Vector2(300, 0);
        PopulateRseumes();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveResume)
        {
            moveTime += Time.deltaTime;

            if (resumes[listPos].transform.position.x != oGPos.x)
            {
                if (moveTime > 1)
                {
                    moveTime = 1;
                    moveResume = false;
                }
                float x = Mathf.Lerp(slideStart.x, oGPos.x, moveTime * slideSpeed);
                resumes[listPos].transform.position = new Vector2( x, resumes[listPos].transform.position.y);
            }
        }

        float scroll = Input.mouseScrollDelta.y;

        if(scroll > 0 || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            NextInList();
        }
        else if (scroll < 0 || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            PrevInList();
        }
    }

    private void PopulateRseumes()
    {
        ResumeHolder resScript;
        GameObject currentResume;
        //Clears array if it has anything in it
        if (resumes.Count > 0)
        {
            for (int i = 0; i < resumes.Count; i++)
                Destroy(resumes[i]);
            resumes.Clear();
        }

        //Fills array
        for(int i = 0; i < numberOfResumes; i++)
        {
            currentResume = Instantiate(resumePrefab, spawnPoint.transform);
            resumes.Add(currentResume);
            resScript = resumes[i].GetComponent<ResumeHolder>();
            resScript.applicant_name = "Ms." + i;
            resScript.applicant_age = i + " Years old";
            resScript.applicant_work_history = "Worked at Deez for " + i + " years";
            resScript.applicant_education = "Graduated form " + i + " University";
            resScript.FillResume();
            currentResume.SetActive(false);
        }
        resumes[0].SetActive(true);
        listPos = 0;
    }

    public void NextInList()
    {
        if (listPos == resumes.Count - 1)
        {
            //If at end we go to the end of
            resumes[listPos].SetActive(false);
            listPos = 0;
            resumes[listPos].SetActive(true);
            MovePage(resumes[listPos]);
        }
        else
        {
            //Else gose to next resume in array
            resumes[listPos].SetActive(false);
            listPos++;
            resumes[listPos].SetActive(true);
            MovePage(resumes[listPos]); 
        }
    }

    public void PrevInList()
    {
        if (listPos == 0)
        {
            //If at 0 we go to the end of
            resumes[listPos].SetActive(false);
            listPos = resumes.Count - 1;
            resumes[listPos].SetActive(true);
            MovePage(resumes[listPos]);
        }
        else
        {
            //Else gose to previous resume in array
            resumes[listPos].SetActive(false);
            listPos--;
            resumes[listPos].SetActive(true);
            MovePage(resumes[listPos]);
        }
    }

    public void GoToInList(int resumeX)
    {
        for (int i = 0; i < resumes.Count; i++)
            resumes[i].SetActive(false);
        listPos = resumeX;
        resumes[listPos].SetActive(true);
        MovePage(resumes[listPos]);
    }

    private void MovePage(GameObject resume)
    {
        resume.transform.position = slideStart;
        moveResume = true;
        moveTime = 0;
    }
}
