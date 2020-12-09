using UnityEngine;

public abstract class BaseState
{
    protected readonly GameObject GameObject;

    protected BaseState(GameObject gameObject)
    {
        GameObject = gameObject;
    }

    public abstract NpcState Tick();
}
