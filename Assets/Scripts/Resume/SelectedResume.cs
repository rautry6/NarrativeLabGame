using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectedResume : MonoBehaviour
{
    [SerializeField] private TMP_Text displayText;
    [SerializeField] private ResumeHolder[] resumes;
    [SerializeField] private int currentResume = 0;
    // Start is called before the first frame update
    void Awake()
    {
        displayText = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowResume(Resume resume)
    {
        displayText.text =
            "Name: " + resume.applicant_name + "\n" + 
            "DOB: " + resume.applicant_age + "\n" +
            "Sex: " + resume.applicant_sex + "\n" +
            "Race: " + resume.applicant_race + "\n" +
            "Skills: " + resume.applicant_skills + "\n" +
            "Work History: " + resume.applicant_work_history + "\n" +
            "Education: " + resume.applicant_education;

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
