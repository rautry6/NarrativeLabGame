using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectedResume : MonoBehaviour
{
    [SerializeField] private TMP_Text displayText;
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
            "Age: " + resume.applicant_age + "\n" +
            "Sex: " + resume.applicant_sex + "\n" +
            "Race: " + resume.applicant_race + "\n" +
            "Skills: " + resume.applicant_skills + "\n" +
            "Work History: " + resume.applicant_work_history + "\n" +
            "Education: " + resume.applicant_education;
    }
}
