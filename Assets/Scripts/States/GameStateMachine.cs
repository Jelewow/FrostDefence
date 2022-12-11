using System;
using System.Collections.Generic;
using Jelewow.FrostDefence.Core;

namespace Jelewow.FrostDefence.Infrastructure.States
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type,IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain loadingCurtain)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, loadingCurtain),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }
        
        public void Enter<TState>() where TState : class, IState
        {
            IState state = EnterState<TState>(); 
            state.Enter();
        }
        
        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = EnterState<TState>();
            state.Enter(payload);
        }
        
        private TState EnterState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            var state = GetState<TState>(); 
            _activeState = state;
            return state;
        }
        
        private TState GetState<TState>() where TState : class, IExitableState 
        {
            return _states[typeof(TState)] as TState ;
        }
    }
}