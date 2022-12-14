using UnityEngine;

namespace Jelewow.FrostDefence.Infrastructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        public void Instantiate(string path)
        {
            Object.Instantiate(Resources.Load<GameObject>(path));
        }
        
        public GameObject Instantiate(string path, Vector3 position)
        {
            return Object.Instantiate(Resources.Load<GameObject>(path), position, Quaternion.identity);
        }
    }
}