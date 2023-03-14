using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTransitionManager : MonoBehaviour
{
    [Header("Game Events")]
    [SerializeField] private GameEvent StartDay;
    [SerializeField] private GameEvent EndDay;

    private void Start()
    {
        StartDay.TriggerEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Dayover()
    {
        EndDay.TriggerEvent();
    }
}
