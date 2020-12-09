public class State1 : BaseState
{
    private Npc _npc;
    
    public State1(Npc npc) : base(npc.gameObject)
    {
        _npc = npc;
    }

    public override NpcState Tick()
    {
        return NpcState.State1;
    }
}
