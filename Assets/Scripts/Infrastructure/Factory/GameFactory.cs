using Jelewow.FrostDefence.Auxiliary;
using Jelewow.FrostDefence.Infrastructure.AssetManagement;
using UnityEngine;

namespace Jelewow.FrostDefence.Infrastructure
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider; 
        }
        
        public GameObject CreateHero(Vector3 position)
        {
            return _assetProvider.Instantiate(GameConstants.Resources.Player, position);
        }

        public void CreateHud()
        {
            _assetProvider.Instantiate(GameConstants.Resources.Hud);
        }
    }
}