using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectedResume : MonoBehaviour
{
    [SerializeField] private TMP_Text[] displayText;
    [SerializeField] private ResumeHolder[] resumes;
    [SerializeField] private int currentResume = 0;
    [SerializeField] private GameObject pictureHolder;
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
        if(resume.applicant_image != null)
        {
            pictureHolder.GetComponent<Image>().sprite = resume.applicant_image;
        }
        else
        {
            pictureHolder.GetComponent<Image>().sprite = null;
        }

        displayText[0].text = resume.applicant_name;
        displayText[1].text = "DOB: " + resume.applicant_age;
        displayText[2].text = "SEX: " + resume.applicant_sex;
        displayText[3].text = "RACE: " + resume.applicant_race;
        displayText[4].text = "SKILLS: " + resume.applicant_skills + "\n\n" + "WORK HISTORY: " + resume.applicant_work_history + "\n\n" + "EDUCATION: " + resume.applicant_education;
        displayText[5].text = "";
        displayText[6].text = "";

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
