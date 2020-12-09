using UnityEngine;

public abstract class BaseState
{
    protected readonly GameObject GameObject;

    protected BaseState(GameObject gameObject)
    {
        GameObject = gameObject;
    }

    public abstract void Start();
    
    public abstract NpcState Tick();
    
    public abstract void Stop();
}
