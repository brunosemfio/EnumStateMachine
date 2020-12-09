using UnityEngine;

public class State2 : IBaseState
{
    private static readonly int Anim = Animator.StringToHash("Horizontal");
    
    private readonly Npc _npc;
    
    private readonly Animator _animator;

    private float _counter;

    public State2(Npc npc, Animator animator)
    {
        _npc = npc;
        
        _animator = animator;
    }

    public void Start()
    {
        _animator.SetTrigger(Anim);
    }

    public NpcState Tick()
    {
        _counter += Time.deltaTime;

        if (_counter >= 2f)
        {
            _counter = 0f;

            return NpcState.State1;
        }
        
        return NpcState.State2;
    }

    public void Stop()
    {
        _animator.ResetTrigger(Anim);
    }
}