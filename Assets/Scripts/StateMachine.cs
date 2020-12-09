using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine<T> : MonoBehaviour where T : Enum
{
    private Dictionary<T, IBaseState<T>> _states;

    public T CurrentState { get; private set; }

    public event Action<T> OnStateChanged;

    public void SetStates(Dictionary<T, IBaseState<T>> states, T initial)
    {
        _states = states;

        CurrentState = initial;

        _states[CurrentState].Start();
    }

    private void Update()
    {
        var nextState = _states[CurrentState].Update(this);

        if (!Equals(nextState, CurrentState)) ChanceState(nextState);
    }

    private void ChanceState(T nextState)
    {
        _states[CurrentState].Stop();

        CurrentState = nextState;

        _states[CurrentState].Start();

        OnStateChanged?.Invoke(CurrentState);
    }
}