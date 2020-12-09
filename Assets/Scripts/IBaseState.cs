using System;

public interface IBaseState<T> where T : Enum
{
    void Start();

    T Update(StateMachine<T> sm);

    void Stop();
}