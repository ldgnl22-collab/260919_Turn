using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModule : MonoBehaviour
{
    public List<Phase> Phases = new List<Phase>();

    public bool IsFinished { get; private set; }

    // private void Awake() => Init();
    //
    // private void Init()
    // {
    //     foreach (Phase phase in Phases)
    //     {
    //         phase.Init();
    //     }
    // }

    // public void AddPhase(params Phase[] phases)
    // {
    //     foreach (Phase phase in phases)
    //     {
    //         Phases.Add(phase);
    //     }
    // }

    public void AddPhase(Phase phase)
    {
        Phases.Add(phase);
    }
    
    public void ResetPhases()
    {
        IsFinished = false;

        foreach (Phase phase in Phases)
        {
            phase.Reset();
        }
    }

    public IEnumerator PhaseRoutine()
    {
        for (int i = 0; i < Phases.Count; i++)
        {
            Phase currentPhase = Phases[i];

            while (!currentPhase.IsFinished)
            {
                currentPhase.Update();
                yield return null;
            }

            yield return currentPhase.WaitDelay;
        }

        IsFinished = true;
    }
}
