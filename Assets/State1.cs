using UnityEngine;

public class State1 : BaseState
{
    private readonly Npc _npc;
    
    private float _counter;
    
    public State1(Npc npc) : base(npc.gameObject)
    {
        _npc = npc;
    }

    public override NpcState Tick()
    {
        _counter += Time.deltaTime;

        if (_counter >= 2f)
        {
            _counter = 0f;

            return NpcState.State2;
        }
        
        return NpcState.State1;
    }
}
