public class State2 : BaseState
{
    private Npc _npc;
    
    public State2(Npc npc) : base(npc.gameObject)
    {
        _npc = npc;
    }

    public override NpcState Tick()
    {
        return NpcState.State2;
    }
}