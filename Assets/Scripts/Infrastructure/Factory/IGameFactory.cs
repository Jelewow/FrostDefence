using System.Collections.Generic;
using Jelewow.FrostDefence.Infrastructure.Services;
using Jelewow.FrostDefence.Services.PersistantProgress;
using UnityEngine;

namespace Jelewow.FrostDefence.Infrastructure
{
    public interface IGameFactory : IService
    {
        public List<ISavedProgressReader> ProgressReaders { get; }
        public List<ISavedProgress> ProgressWriters { get; }
        
        public GameObject CreateHero(Vector3 position);

        public void CreateHud();
        
        public void Cleanup();
    }
}