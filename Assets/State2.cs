﻿using UnityEngine;

public class State2 : BaseState
{
    private readonly Npc _npc;

    private float _counter;
    
    public State2(Npc npc) : base(npc.gameObject)
    {
        _npc = npc;
    }

    public override NpcState Tick()
    {
        Debug.Log($"{GameObject.name} no state '{ToString()}'");

        _counter += Time.deltaTime;

        if (_counter >= 2f)
        {
            _counter = 0f;

            return NpcState.State1;
        }
        
        return NpcState.State2;
    }
}