namespace Jelewow.FrostDefence.Infrastructure
{
    public interface IState : IExitableState
    {
        public void Enter(); 
    }

    public interface IExitableState
    {
        public void Exit();
    }
    
    public interface IPayloadedState<TPayload>  : IExitableState
    {
        public void Enter(TPayload payload);
    }
}