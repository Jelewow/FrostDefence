using System.Collections.Generic;
using Jelewow.FrostDefence.Auxiliary;
using Jelewow.FrostDefence.Infrastructure.AssetManagement;
using Jelewow.FrostDefence.Services.PersistantProgress;
using UnityEngine;

namespace Jelewow.FrostDefence.Infrastructure
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public List<ISavedProgressReader> ProgressReaders { get; } = new ();
        public List<ISavedProgress> ProgressWriters { get; } = new ();
        
        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider; 
        }
        
        public GameObject CreateHero(Vector3 position)
        {
            return InstantiateRegistered(GameConstants.Resources.Player, position);
        }

        public void CreateHud()
        {
            InstantiateRegistered(GameConstants.Resources.Hud);
        }

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        private GameObject InstantiateRegistered(string prefabPath, Vector3 position)
        {
            var gameObject = _assetProvider.Instantiate(prefabPath, position);
            return RegisterProgressServices(gameObject);
        }
         
        private GameObject InstantiateRegistered(string prefabPath)
        {
            var gameObject = _assetProvider.Instantiate(prefabPath);
            return RegisterProgressServices(gameObject);
        }

        private GameObject RegisterProgressServices(GameObject gameObject)
        {
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }
        
        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (var progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
            {
                Register(progressReader);
            }
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
            {
                ProgressWriters.Add(progressWriter);
            }
            
            ProgressReaders.Add(progressReader);
        }
    }
}