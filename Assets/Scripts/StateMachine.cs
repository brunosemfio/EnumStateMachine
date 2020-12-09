using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private Dictionary<NpcState, IBaseState> _states;
    
    public NpcState CurrentState { get; private set; }

    public event Action<NpcState> OnStateChanged;

    public void SetStates(Dictionary<NpcState, IBaseState> states, NpcState initial)
    {
        _states = states;

        CurrentState = initial;
        
        _states[CurrentState].Start();
    }

    private void Update()
    {
        var nextState = _states[CurrentState].Tick();

        if (nextState != CurrentState) ChanceState(nextState);
    }

    private void ChanceState(NpcState nextState)
    {
        _states[CurrentState].Stop();

        CurrentState = nextState;

        _states[CurrentState].Start();

        OnStateChanged?.Invoke(CurrentState);
    }
}
