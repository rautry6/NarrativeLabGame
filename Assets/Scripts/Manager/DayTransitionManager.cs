using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTransitionManager : MonoBehaviour
{
    [Header("Game Events")]
    [SerializeField] private GameEvent StartDay;
    [SerializeField] private GameEvent EndDay;

    private void Awake()
    {
        StartDay.TriggerEvent();
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
