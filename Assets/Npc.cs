using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public class Npc : MonoBehaviour
{
    private StateMachine _stateMachine;

    [SerializeField] private NpcState initialState;

    private void Awake()
    {
        _stateMachine = GetComponent<StateMachine>();
    }

    private void Start()
    {
        var states = new Dictionary<NpcState, BaseState>
        {
            {NpcState.State1, new State1(this)},
            {NpcState.State2, new State2(this)}
        };

        _stateMachine.SetStates(states, initialState);
    }

    private void FixedUpdate()
    {
        Debug.Log($"Current State: {_stateMachine.CurrentState}");
    }
}