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

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null && dragDropHandler.numRejected < 3)
        {
            GetComponentInChildren<TMP_Text>().color = eventData.pointerDrag.GetComponentInChildren<TMP_Text>().color;
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
}
