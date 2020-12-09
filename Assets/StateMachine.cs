using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private Dictionary<NpcState, BaseState> _states;
    
    public NpcState CurrentState { get; private set; }

    public event Action<NpcState> OnStateChanged;

    public void SetStates(Dictionary<NpcState, BaseState> states, NpcState initial)
    {
        _states = states;

        CurrentState = initial;
    }

    private void Update()
    {
        var nextState = _states[CurrentState].Tick();

        if (nextState == CurrentState) return;
        
        CurrentState = nextState;
            
        OnStateChanged?.Invoke(CurrentState);
    }
}
