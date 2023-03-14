using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyEventManager : MonoBehaviour
{
    [Header("Game Events")]
    [SerializeField] private GameEvent FinalEventComplete;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Test());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Test()
    {
        yield return new WaitForSeconds(3f);

        FinalEventComplete.TriggerEvent();
    }
}
