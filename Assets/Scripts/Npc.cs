using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NpcStateMachine))]
public class Npc : MonoBehaviour
{
    private NpcStateMachine _stateMachine;

    private Animator _animator;

    [SerializeField] private NpcState initialState;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        
        _stateMachine = GetComponent<NpcStateMachine>();
    }

    private void Start()
    {
        var states = new Dictionary<NpcState, IBaseState<NpcState>>
        {
            {NpcState.State1, new State1(this, _animator)},
            {NpcState.State2, new State2(this, _animator)}
        };

        _stateMachine.SetStates(states, initialState);
    }

    private void FixedUpdate()
    {
        Debug.Log($"Current State: {_stateMachine.CurrentState}");
    }
}