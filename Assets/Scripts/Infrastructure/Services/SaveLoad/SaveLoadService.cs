using Jelewow.FrostDefence.Auxiliary;
using Jelewow.FrostDefence.Auxiliary.Extensions;
using Jelewow.FrostDefence.Data;
using UnityEngine;

namespace Jelewow.FrostDefence.Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly IPersistantProgressService _progressService;
        private readonly IGameFactory _gameFactory;

        public SaveLoadService(IPersistantProgressService progressService, IGameFactory gameFactory)
        {
            _progressService = progressService;
            _gameFactory = gameFactory;
        }
        
        public void SaveProgress()
        {
            foreach (var progressWriter in _gameFactory.ProgressWriters)
            {
                progressWriter.UpdateProgress(_progressService.Progress);
            }
            
            PlayerPrefs.SetString(GameConstants.PrefKeys.Progress, _progressService.Progress.ToJson());
        }
        
        public PlayerProgress LoadProgress()
        {
            return PlayerPrefs.GetString(GameConstants.PrefKeys.Progress)?.ToDeserialized<PlayerProgress>();
        }
    }
}