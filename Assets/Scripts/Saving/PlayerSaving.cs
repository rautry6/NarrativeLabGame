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
    private float referallsAccepted = 0;
    private float referallsOffered = 0;
    private bool bossReferrals = false;
    private bool friendReferrals = false;
    private float bossRelationship = 25f;
    private float friendRelationship = 75f;
    private bool sitWithFriend = true;
    private bool meetWithBoss = true;
    private bool bossMad = false;
    private bool friendMad = false;

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

        Debug.Log(referallsAccepted);
        File.WriteAllText(path, 
            "ReferallsAccepted " + referallsAccepted.ToString() + "\n" +
            "ReferrallsOffered " + referallsOffered.ToString() + "\n" +
            "BossReferrals " + bossReferrals.ToString() + "\n" +
            "FriendReferrals " + friendReferrals.ToString() + "\n" +
            "BossRelationship " + bossRelationship.ToString() + "\n" +
            "FriendRelationship " + friendRelationship.ToString() + "\n" +
            "SitWithFriend " + sitWithFriend.ToString() + "\n" +
            "MeetWithBoss " + meetWithBoss.ToString() + "\n" +
            "DaysCompleted " + daysCompleted.ToString() + "\n" +
            "BossMad " + bossMad.ToString() + "\n" +
            "FriendMad " + friendMad.ToString() + "\n"
            );

        Debug.Log("Data saved");
        DayOver.TriggerEvent();
    }

    public void ReadSavedData()
    {
        CheckForFile();

        StreamReader sr = new StreamReader(path);
        string data = sr.ReadLine();

        while (data != null)
        {
            //Splits data by space delimeter
            string[] split = data.Split(' ');

            switch (split[0])
            {
                case "ReferallsAccepted":
                    referallsAccepted = float.Parse(split[1]);
                    break;

                case "ReferrallsOffered":
                    referallsOffered = float.Parse(split[1]);
                    break;

                case "BossReferrals":
                    bossReferrals = bool.Parse(split[1]);
                    break;

                case "FriendReferrals":
                    friendReferrals = bool.Parse (split[1]);
                    break;

                case "BossRelationship":
                    bossRelationship = float.Parse(split[1]);
                    break;

                case "FriendRelationship":
                    friendRelationship = float.Parse(split[1]);
                    break;

                case "SitWithFriend":
                    sitWithFriend = bool.Parse(split[1]);
                    break;

                case "MeetWithBoss":
                    meetWithBoss = bool.Parse(split[1]);
                    break;

                case "DaysCompleted":
                    daysCompleted = int.Parse(split[1]);
                    break;

                case "BossMad":
                    bossMad = bool.Parse(split[1]);
                    break;

                case "FriendMad":
                    friendMad = bool.Parse(split[1]);
                    break;
            }
            data = sr.ReadLine();
        }
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

    /// <summary>
    /// Player has upset their boss with their decisions
    /// </summary>
    public void BossIsMad()
    {
        bossMad = true;
    }

    /// <summary>
    /// Player has upset their friend with their decisions
    /// </summary>
    public void FriendIsMad()
    {
        friendMad = true;
    }

}
