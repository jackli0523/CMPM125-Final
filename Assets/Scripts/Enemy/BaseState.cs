public abstract class BaseState{
    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void PhysicsUpdate();
    public abstract void LogicUpdate();
}