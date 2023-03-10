using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerSaving : MonoBehaviour
{
    [Header("Game Events")]
    [SerializeField] private GameEvent DayOver;

    private string path;

    [Header("Data Fields")]
    [SerializeField] private float referallsAccepted = 0;
    [SerializeField] private float referallsOffered = 0;
    [SerializeField] private bool bossReferrals = false;
    [SerializeField] private bool friendReferrals = false;
    [SerializeField] private float bossRelationship = 25f;
    [SerializeField] private float friendRelationship = 75f;
    [SerializeField] private bool sitWithFriend = true;
    [SerializeField] private bool meetWithBoss = true;
    [SerializeField] private bool bossMad = false;
    [SerializeField] private bool friendMad = false;

    public float ReferallsAccepted { get { return referallsAccepted; }  }

    public float ReferallsOffered { get { return referallsOffered; } }

    public bool BossReferrals { get { return bossReferrals; } }

    public bool FriendReferrals { get { return friendReferrals; } }

    public bool SitWithFriend { get { return sitWithFriend; } }

    public bool MeetWithBoss { get { return meetWithBoss; } }

    public bool BossMad { get { return bossMad; } }

    public bool FriendMad { get { return friendMad; } }

    private int daysCompleted = 0;

    // Start is called before the first frame update
    void Awake()
    {
        path = Application.dataPath + "/PlayerData.txt";
        CheckForFile();
    }

    public void SaveData()
    {
        CheckForFile(); //Makes sure the file is there to save into
        daysCompleted++;

        File.WriteAllText(path, 
            "ReferallsAccepted " + referallsAccepted.ToString() + "\n" +
            "ReferrallsOffered " + referallsOffered.ToString() + "\n" +
            "BossReferrals " + bossReferrals.ToString() + "\n" +
            "FriendReferrals " + friendReferrals.ToString() + "\n" +
            "BossRelationship " + bossRelationship.ToString() + "\n" +
            "FriendRelationship " + friendRelationship.ToString() + "\n" +
            "SitWithFriend " + sitWithFriend.ToString() + "\n" +
            "MeetWithBoss " + meetWithBoss.ToString() + "\n" +
            "DaysCompleted " + daysCompleted.ToString() + "\n"
            );

        DayOver.TriggerEvent();
    }

    public void CheckForFile()
    {
        if(!File.Exists(path))
        {
            File.WriteAllText(path, "");
        }
    }

    /// <summary>
    /// Updates the boss relationship with the amount passed in
    /// </summary>
    /// <param name="amount"></param>
    public void UpdateBossRelationship(float amount)
    {
        bossRelationship += amount;
    }

    /// <summary>
    /// Updates the friend relationship with the amount passed in
    /// </summary>
    /// <param name="amount"></param>
    public void UpdateFriendRelationship(float amount)
    {
        friendRelationship += amount;
    }

    /// <summary>
    /// Boss gave player referrals
    /// </summary>
    public void BossReferals()
    {
        bossReferrals = true;
        friendReferrals = false;
    }

    /// <summary>
    /// Friend gave player referrals
    /// </summary>
    public void FriendReferals()
    {
        friendReferrals = true;
        bossReferrals= false;
    }

    /// <summary>
    /// Player accepted one of the resumes that was a referral
    /// </summary>
    public void ReferalAccepted()
    {
        referallsAccepted++;
    }

    /// <summary>
    /// Resets the referall data values
    /// </summary>
    public void ResetReferalls()
    {
        referallsAccepted = 0;
        referallsOffered = 0;
    }

    /// <summary>
    /// Updates the referrals offered field with the number of referrals the boss / friend gave to the player
    /// </summary>
    /// <param name="amount"></param>
    public void ReferalsGiven(float amount)
    {
        referallsOffered += amount;
    }

    /// <summary>
    /// Player is not sitting with their friend tomorrow
    /// </summary>
    public void NotSittingWithFriend()
    {
        sitWithFriend = false;
    }

    /// <summary>
    /// Player is sitting with their friend tomorrow
    /// </summary>
    public void SittingWithFriend()
    {
        sitWithFriend = true;
    }

    /// <summary>
    /// Player is not meeting with their boss tomorrow
    /// </summary>
    public void NotMeetingBoss()
    {
        meetWithBoss = false;
    }

    /// <summary>
    /// Player is meeting with their boss tomorrow
    /// </summary>
    public void MeetingWithBoss()
    {
        meetWithBoss = true;
    }

    public void BossIsMad()
    {
        bossMad = true;
    }

    public void FriendIsMad()
    {
        friendMad = true;
    }
}
