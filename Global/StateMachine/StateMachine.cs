public class StateMachine
{
    public State CurrentState { get; private set; }
    public void Initialize(State initializeState)
    {
        CurrentState = initializeState;
        CurrentState.Enter();
    }
    public void SetNewState(State newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
