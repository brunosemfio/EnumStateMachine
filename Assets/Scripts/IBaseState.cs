public interface IBaseState
{
    void Start();

    NpcState Tick();

    void Stop();
}