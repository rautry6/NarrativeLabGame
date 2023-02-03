using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Applicant_Resume", menuName = "Resume/BlankResume")]
public class Resume : ScriptableObject
{
    public int resumeNum;
    public Image applicant_image;
    public string applicant_name;
    public string applicant_age;
    public string applicant_sex;
    public string applicant_race;
    public string applicant_skills;
    public string applicant_work_history;
    public string applicant_education;
    public string applicant_likes;
    public string applicant_dislikes;
}
