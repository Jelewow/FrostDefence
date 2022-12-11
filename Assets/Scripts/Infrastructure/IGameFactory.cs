using UnityEngine;

namespace Jelewow.FrostDefence.Infrastructure
{
    public interface IGameFactory
    {
        public GameObject CreateHero(Vector3 position);

        public void CreateHud();
    }
}