using Jelewow.FrostDefence.Auxiliary;
using Jelewow.FrostDefence.Core;
using Jelewow.FrostDefence.Infrastructure.Services;
using UnityEngine;

namespace Jelewow.FrostDefence.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistantProgressService _progressService;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain,
            IGameFactory gameFactory, IPersistantProgressService progressService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _progressService = progressService;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _gameFactory.Cleanup();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            _loadingCurtain.Hide();
        }

        private void OnLoaded()
        {
            _gameFactory.CreateHero(GameObject.FindWithTag(GameConstants.Tags.InitialPoint).transform.position);
            InformProgressReader();

            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InformProgressReader()
        {
            foreach (var progressReader in _gameFactory.ProgressReaders)
            {
                Debug.Log(_progressService.Progress);
                progressReader.LoadProgress(_progressService.Progress);
            }
        }
    }
}