using UnityEngine;

public class State1 : IBaseState<NpcState>
{
    private static readonly int Anim = Animator.StringToHash("Vertical");
    
    private readonly Npc _npc;
    
    private readonly Animator _animator;

    private float _counter;

    public State1(Npc npc, Animator animator)
    {
        _npc = npc;
        
        _animator = animator;
    }

    public void Start()
    {
        _animator.SetTrigger(Anim);
    }

    public NpcState Update(StateMachine<NpcState> stateMachine)
    {
        _counter += Time.deltaTime;

        if (_counter >= 2f)
        {
            _counter = 0f;

            return NpcState.State2;
        }
        
        return stateMachine.CurrentState;
    }

    public void Stop()
    {
        _animator.ResetTrigger(Anim);
    }
}
