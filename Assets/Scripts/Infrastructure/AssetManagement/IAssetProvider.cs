 using UnityEngine;

namespace Jelewow.FrostDefence.Infrastructure.AssetManagement
{
    public interface IAssetProvider
    {
        public void Instantiate(string path);
        public GameObject Instantiate(string path, Vector3 position);
    }
}