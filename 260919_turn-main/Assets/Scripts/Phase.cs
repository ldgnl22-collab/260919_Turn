using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Phase
{
    [SerializeField] private string _name;
    public UnityEvent OnPhaseRunning = new();
    public float FinishDelay;
    public bool IsFinished;

    public WaitForSeconds WaitDelay;
    public WaitUntil WaitFinish;

    public Phase()
    {
        Init();
        Reset();
    }
    
    public void Update()
    {
        OnPhaseRunning?.Invoke();
    }

    public void Reset()
    {
        IsFinished = false;
    }

    public void Init()
    {
        WaitDelay = new WaitForSeconds(FinishDelay);
        WaitFinish = new WaitUntil(() => IsFinished);
    }
}
