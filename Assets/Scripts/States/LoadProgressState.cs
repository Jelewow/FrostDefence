using Jelewow.FrostDefence.Auxiliary;
using Jelewow.FrostDefence.Data;
using Jelewow.FrostDefence.Infrastructure.Services;
using Jelewow.FrostDefence.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace Jelewow.FrostDefence.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistantProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMachine gameStateMachine, IPersistantProgressService progressService,
            ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            _gameStateMachine.Enter<LoadLevelState, string>(_progressService.Progress.WorldData.CameraPositionOnLevel
                .Level);
            
            //_gameStateMachine.Enter<LoadLevelState, string>(GameConstants.Scenes.Main);
        }

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew()
        {
            _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();
        }

        private PlayerProgress NewProgress()
        {
            Debug.Log("load");
            return new PlayerProgress(GameConstants.Scenes.Main);
        }
    }
}