using Jelewow.FrostDefence.Infrastructure.Services;
using UnityEngine;

namespace Jelewow.FrostDefence.Infrastructure
{
    public interface IGameFactory : IService
    {
        public GameObject CreateHero(Vector3 position);

        public void CreateHud();
    }
}