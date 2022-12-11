using System;
using Jelewow.FrostDefence.Auxiliary;
using UnityEngine;

namespace Jelewow.FrostDefence.Infrastructure
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(GameConstants.Scenes.Initial, EnterLoadLevel);
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>(GameConstants.Scenes.Main);
        }

        public void Exit()
        {
            
        }
        
        private void RegisterServices()
        {
            
        }
    }
}