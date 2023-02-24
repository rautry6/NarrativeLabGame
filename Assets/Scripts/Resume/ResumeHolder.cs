using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResumeHolder : MonoBehaviour
{

    [SerializeField] private DragDropHandler dragDropHandler;
    [SerializeField] private GameObject selectedResume;
    [SerializeField] public int resumeNum;
    [SerializeField] public Resume resume;
    [SerializeField] private GameObject rejectMark;
    [SerializeField] private GameObject acceptMark;

    public string applicant_name;
    public string applicant_age;
    public string applicant_sex;
    public string applicant_race;
    public string applicant_skills;
    public string applicant_work_history;
    public string applicant_education;
    public string applicant_likes;
    public string applicant_dislikes;

    private void Awake()
    {
        
    }
}
