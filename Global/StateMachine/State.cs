public abstract class State
{
    public virtual void PreEnter() { }
    public virtual void Enter() => PreEnter();
    public virtual void Exit() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void OnTriggerStay() { }
}