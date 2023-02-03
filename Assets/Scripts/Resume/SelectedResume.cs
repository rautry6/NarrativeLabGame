using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectedResume : MonoBehaviour
{
    [SerializeField] private TMP_Text[] displayText;
    [SerializeField] private ResumeHolder[] resumes;
    [SerializeField] private int currentResume = 0;
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowResume(Resume resume)
    {
        displayText[0].text = "NAME: " + resume.applicant_name;
        displayText[1].text = "DOB: " + resume.applicant_age;
        displayText[2].text = "SEX: " + resume.applicant_sex;
        displayText[3].text = "RACE: " + resume.applicant_race;
        displayText[4].text = "SKILLS: " + resume.applicant_skills;
        displayText[5].text = "WORK HISTORY: " + resume.applicant_work_history;
        displayText[6].text = "EDUCATION: " + resume.applicant_education;

        currentResume = resume.resumeNum;
    }

    public void DisplayLastResume()
    {
        currentResume--;

        if(currentResume < 0)
        {
            currentResume = resumes.Length -1;
        }

        ShowResume(resumes[currentResume].resume);
    }

    public void DisplayNextResume()
    {
        currentResume++;

        if (currentResume > resumes.Length -1)
        {
            currentResume = 0;
        }

        ShowResume(resumes[currentResume].resume);
    }
}
