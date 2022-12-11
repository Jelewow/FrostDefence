
using Jelewow.FrostDefence.Auxiliary;
using Jelewow.FrostDefence.Core;
using UnityEngine;

namespace Jelewow.FrostDefence.Infrastructure
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded); 
        }
        
        public void Exit()
        {
            _loadingCurtain.Hide(); 
        }
        
        private void OnLoaded()
        {
            _gameFactory.CreateHero(GameObject.FindWithTag(GameConstants.Tags.InitialPoint).transform.position);
            _gameStateMachine.Enter<GameLoopState>() ;
        }
    }
}