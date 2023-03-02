using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResumeHolder : MonoBehaviour, IDropHandler, IPointerDownHandler
{

    [SerializeField] private DragDropHandler dragDropHandler;
    [SerializeField] private GameObject selectedResume;
    [SerializeField] public int resumeNum;
    [SerializeField] public Resume resume;
    [SerializeField] private GameObject rejectMark;
    [SerializeField] private TMP_Text nameText, ageText, sexText, raceText, skillsText,
        workHistoryText, educationText, likesText, dislikesText;

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
        FillResume();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null && dragDropHandler.numRejected < 3)
        {
            //GetComponentInChildren<TMP_Text>().color = eventData.pointerDrag.GetComponentInChildren<TMP_Text>().color;
            dragDropHandler.numRejected++;
            eventData.pointerDrag.GetComponent<DragDrop>().PlayStampSound();
            rejectMark.SetActive(true);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        selectedResume.SetActive(true);
        selectedResume.GetComponent<SelectedResume>().ShowResume(resume);
    }

    public void FillResume()
    {
        //did this because I need its
        if (applicant_name != null && nameText != null)
            nameText.text = applicant_name;
        if (applicant_age != null && ageText != null)
            ageText.text = applicant_age;
        if (applicant_sex != null && sexText != null)
            sexText.text = applicant_sex;
        if (applicant_race != null && raceText != null)
            raceText.text = applicant_race;
        if (applicant_skills != null && skillsText != null)
            skillsText.text = applicant_skills;
        if (applicant_work_history != null && workHistoryText != null)
            workHistoryText.text = applicant_work_history;
        if (applicant_education != null && educationText != null)
            educationText.text = applicant_education;
        if (applicant_likes != null && likesText != null)
            likesText.text = applicant_likes;
        if (applicant_dislikes != null && dislikesText != null)
            dislikesText.text = applicant_dislikes;
    }
}
